Imports System.Web.Http
Imports Owin

Public Class Startup
    Public Sub Configuration(appBuilder As IAppBuilder)
        Dim config = New HttpConfiguration()
        'config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{serviceName}", New With {.serviceName = RouteParameter.Optional})
        config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}/{serviceName}", New With {.action = "get", .serviceName = RouteParameter.Optional})

        appBuilder.UseWebApi(config)
    End Sub

End Class
