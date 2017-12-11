Imports Microsoft.Owin.Hosting

Module Program

    Sub Main()
        Dim baseAddress = "http://*:9000"
        Using WebApp.Start(Of Startup)(url:=baseAddress)
            Console.WriteLine("Press enter to exit ...")
            Console.ReadLine()
        End Using
    End Sub

End Module
