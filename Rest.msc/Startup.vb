Imports System.Security.Claims
Imports System.Web.Http
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.ApiKey
Imports Microsoft.Owin.Security.ApiKey.Contexts
Imports Microsoft.Owin.Security.Infrastructure
Imports Owin
Imports Rest.msc
Imports Swashbuckle.Application

Public Class Startup
    Public Sub Configuration(appBuilder As IAppBuilder)
        appBuilder.Use(GetType(AuthMiddleware))
        Dim config = New HttpConfiguration()
        config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}/{serviceName}", New With {.action = "get", .serviceName = RouteParameter.Optional})
        config.EnableSwagger(Function(p) p.SingleApiVersion("v1", "Rest.msc API")).EnableSwaggerUi()
        appBuilder.UseWebApi(config)
    End Sub
End Class

