Imports Microsoft.Owin

Public Class AuthMiddleware
    Inherits OwinMiddleware

    Public Sub New([next] As OwinMiddleware)
        MyBase.New([next])
    End Sub

    Public Overrides Async Function Invoke(context As IOwinContext) As Task
        If String.IsNullOrEmpty(ApiKey) Then
            'No authentication
            Await [Next].Invoke(context)
        Else
            Dim requestApiKey = GetApiKey(context)
            If requestApiKey = ApiKey Then
                Await [Next].Invoke(context)
            Else
                context.Response.Headers.Clear()
                context.Response.StatusCode = 401
                Await context.Response.WriteAsync("401 Unauthorized")
            End If
        End If
    End Function

    Private Shared Function GetApiKey(context As IOwinContext) As String
        Try
            Dim rtnVal = context.Request.Headers.Item("Authorization")
            If String.IsNullOrEmpty(rtnVal) Then Return ""
            Dim arAuth = rtnVal.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Select Case arAuth(0).ToUpperInvariant
                Case "BASIC"
                    Dim apikey = Utils.FromBase64(arAuth(1))
                    Dim keyBytes = apikey.Split(":".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
                    Return keyBytes(1)
                Case "BEARER"
                    Return arAuth(1)
            End Select
            Return ""
        Catch ex As Exception
            'TODO: Log the error
            Return ""
        End Try
    End Function
End Class
