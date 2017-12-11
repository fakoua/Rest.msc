Imports System.Web.Http

Public Class ServicesController
    Inherits ApiController

    Public Async Function [Get]() As Task(Of IEnumerable(Of ServiceModel))
        Return Await ServiceManager.GetServicesAsync
    End Function

    <HttpGet>
    Public Async Function Details(serviceName As String) As Task(Of ServiceModel)
        Return Await ServiceManager.GetServiceAsync(serviceName)
    End Function

    <HttpGet>
    Public Async Function Extended(serviceName As String) As Task(Of ExtendedServiceModel)
        Return Await ServiceManager.GetExtendedServiceAsync(serviceName)
    End Function

    <HttpPost>
    Public Function Start(<FromBody> service As ServiceModel) As String
        Return ServiceManager.ControlService(service.ServiceName, ControlType.StartService).ToString
    End Function

    <HttpPost>
    Public Function [Stop](<FromBody> service As ServiceModel) As String
        Return ServiceManager.ControlService(service.ServiceName, ControlType.StopService).ToString
    End Function

    <HttpPost>
    Public Function Pause(<FromBody> service As ServiceModel) As String
        Return ServiceManager.ControlService(service.ServiceName, ControlType.PauseService).ToString
    End Function

    <HttpPost>
    Public Function [Resume](<FromBody> service As ServiceModel) As String
        Return ServiceManager.ControlService(service.ServiceName, ControlType.ResumeService).ToString
    End Function

End Class
