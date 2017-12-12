Module ModMain

    Friend PortNumber As Integer = 9000
    Friend ApiKey As String = ""
    Friend ServiceServer As IDisposable = Nothing 'For service

    ''' <summary>
    ''' Logging.
    ''' </summary>
    ''' <param name="ex"></param>
    Public Sub PushLog(ex As Exception)
        MsgBox(ex.ToString)
    End Sub
End Module
