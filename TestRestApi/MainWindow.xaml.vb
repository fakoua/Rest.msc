Imports RestSharp
Imports RestSharp.Authenticators

Class MainWindow
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        TxtText.Text = "Loading ..."
        Dim client As New RestClient("http://localhost:9000")
        Dim request As New RestRequest("api/services/details/RpcSs") 'Get Remote procedure call info
        Dim response = Await client.ExecuteTaskAsync(request)
        Dim content = response.Content
        TxtText.Text = content
    End Sub

    Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        TxtLoading.Text = "Loading ..."
        Dim client As New RestClient("http://localhost:9000")
        Dim request As New RestRequest("api/services") 'Get Remote procedure call info
        Dim response = Await client.ExecuteGetTaskAsync(Of List(Of ServiceModel))(request)
        Dg.ItemsSource = response.Data
        TxtLoading.Text = ""
    End Sub

    Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        'Set the apikey in Rest.msc.exe.config

        TxtRes.Text = "Loading ..."
        Dim client As New RestClient("http://localhost:9000")
        Dim request As New RestRequest("api/services/details/RpcSs") 'Get Remote procedure call info
        client.Authenticator = New HttpBasicAuthenticator("apikey", "123")
        Dim response = Await client.ExecuteGetTaskAsync(Of ServiceModel)(request)

        Dim txt As String = ""
        txt &= $"Service Name: {response.Data.ServiceName}{vbNewLine}"
        txt &= $"Display Name: {response.Data.DisplayName}{vbNewLine}"
        txt &= $"Service Path: {response.Data.PathName}{vbNewLine}"
        txt &= $"Service Status: {response.Data.Status}{vbNewLine}"
        TxtRes.Text = txt
    End Sub
End Class
