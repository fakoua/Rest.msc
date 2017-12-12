Imports System.Configuration
Imports Microsoft.Owin.Hosting
Imports Topshelf

Module Program
    Sub Main()

        PortNumber = CInt(GetAppSettingValue("PortNumber", "9000", True))
        ApiKey = GetAppSettingValue("ApiKey", "", False)


        Dim baseAddress = $"http://*:{PortNumber}"
        'Service
        HostFactory.Run(Sub(x)
                            x.Service(Of ServiceRunner)(Sub(sc)
                                                            sc.ConstructUsing(Function(s)
                                                                                  Return New ServiceRunner()
                                                                              End Function)
                                                            sc.WhenStarted(Sub(s)
                                                                               s.Start(baseAddress)
                                                                           End Sub)

                                                            sc.WhenStopped(Sub(s)
                                                                               s.Stop()
                                                                           End Sub)
                                                        End Sub)

                            x.SetServiceName("RestMscAPI")
                            x.SetDisplayName("Rest.msc API")
                            x.SetDescription("Restful API management for Windows Services. Access and control windows services using http commands.")
                            x.RunAsPrompt
                        End Sub)

        If Environment.UserInteractive Then
            Using WebApp.Start(Of Startup)(url:=baseAddress)
                Console.WriteLine($"Listining on ({baseAddress}). Press enter to exit ...")
                Console.ReadLine()
            End Using
        End If
    End Sub

    Private Function GetAppSettingValue(keyName As String, defaultValue As String, defaultIfEmpty As Boolean) As String
        Try
            Dim rtnVal = ConfigurationManager.AppSettings(keyName)
            If String.IsNullOrEmpty(rtnVal) Then
                Return If(defaultIfEmpty, defaultValue, "")
            Else
                Return rtnVal
            End If
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function
End Module
