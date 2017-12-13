Imports System.Web.Http
Imports Owin
Imports Swashbuckle.Application

Public Class Startup
    Public Sub Configuration(appBuilder As IAppBuilder)
        appBuilder.Use(GetType(AuthMiddleware))
        Dim config = New HttpConfiguration()
        config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}/{serviceName}", New With {.action = "get", .serviceName = RouteParameter.Optional})
        config.EnableSwagger(Function(p)
                                 Return p.SingleApiVersion("v1", "Rest.msc API")
                             End Function).EnableSwaggerUi()
        appBuilder.UseWebApi(config)

    End Sub
End Class

