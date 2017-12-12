Public Class Utils
    Public Shared Function FromBase64(input As String) As String
        Dim bytes = Convert.FromBase64String(input)
        Dim rtnVal = Text.Encoding.Default.GetString(bytes)
        Return rtnVal
    End Function
End Class
