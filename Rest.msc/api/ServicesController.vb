Imports System.Web.Http

Public Class ServicesController
    Inherits ApiController

    Public Async Function [Get]() As Task(Of IEnumerable(Of ServiceModel))
        Return Await ServiceManager.GetServicesAsync
    End Function

    Public Async Function [Get](serviceName As String) As Task(Of ServiceModel)
        Return Await ServiceManager.GetServiceAsync(serviceName)
    End Function


    Public Sub Post(<FromBody> value As ServiceModel)
        Dim a = value
    End Sub

    Public Sub Put(serviceName As String, <FromBody> value As String)

    End Sub

    Public Sub Delete(serviceName As String)

    End Sub

    <HttpPost>
    Public Function Start(serviceName As String) As Boolean
        Return True
    End Function

End Class
