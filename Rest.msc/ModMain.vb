Module ModMain

    ''' <summary>
    ''' Logging.
    ''' </summary>
    ''' <param name="ex"></param>
    Public Sub PushLog(ex As Exception)
        MsgBox(ex.ToString)
    End Sub
End Module
