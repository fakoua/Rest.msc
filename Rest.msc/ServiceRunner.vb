Imports Microsoft.Owin.Hosting

Public Class ServiceRunner
    Public Sub Start(baseUrl As String)
        ServiceServer = WebApp.Start(Of Startup)(baseUrl)
    End Sub

    Public Sub [Stop]()
        If ServiceServer IsNot Nothing Then
            ServiceServer.Dispose()
        End If
    End Sub

End Class
