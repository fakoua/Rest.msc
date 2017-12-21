Imports System.Security.Principal
Imports NLog

Module ModMain
    Friend tracer As Logger = LogManager.GetLogger("f")
    Friend consoleLogger As Logger = LogManager.GetLogger("c")
    Friend PortNumber As Integer = 9000
    Friend ApiKey As String = ""
    Friend ServiceServer As IDisposable = Nothing 'For service


    Friend Function IsElevated() As Boolean
        Return New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    ''' <summary>
    ''' Logging.
    ''' </summary>
    ''' <param name="ex"></param>
    Public Sub PushLog(ex As Exception)
        MsgBox(ex.ToString)
    End Sub

    Public Sub ConsoleLog(msg As String)
        consoleLogger.Trace(msg)
    End Sub
End Module
