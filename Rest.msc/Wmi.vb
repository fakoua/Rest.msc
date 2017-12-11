Imports System.Globalization
Imports System.Management
Imports System.Threading

Public Class Wmi
    Private _tcsServices As TaskCompletionSource(Of List(Of ServiceModel))

    Async Function GetDependsOnAsync(service As ServiceModel, services As List(Of ServiceModel)) As Task(Of List(Of ServiceModel))
        Try
            _tcsServices = New TaskCompletionSource(Of List(Of ServiceModel))
            Dim th As New Thread(CType(Sub() GetDependsOn(service, services), ThreadStart))
            th.Start()
            Dim rtnVal = Await _tcsServices.Task
            Return rtnVal
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub GetDependsOn(service As ServiceModel, services As List(Of ServiceModel))
        Try
            Dim queryPath = String.Format("SELECT * FROM Win32_DependentService WHERE Dependent='Win32_Service.Name=\'{0}\''", service.ServiceName)
            Dim query As New ObjectQuery(queryPath)
            Dim manScope As New ManagementScope(String.Format(CultureInfo.InvariantCulture, "\\{0}\root\cimv2", service.SystemName))
            manScope.Options.EnablePrivileges = True

            manScope.Connect()
            Dim rtnVal As New List(Of ServiceModel)
            Using mos As ManagementObjectSearcher = New ManagementObjectSearcher(manScope, query)
                Dim queryCollection As ManagementObjectCollection = mos.Get
                'rtnVal.AddRange(From mo As ManagementObject In queryCollection Select serviceName = mo.Item("Antecedent").ToString Select serviceName = GetServiceName(serviceName) Select dependsOnService = services.Where(Function(p) p.ServiceName.ToUpperInvariant = serviceName).FirstOrDefault Where dependsOnService IsNot Nothing)
                For Each mo As ManagementObject In queryCollection
                    Dim serviceName = mo.Item("Antecedent").ToString
                    serviceName = GetServiceName(serviceName)
                    Dim dependsOnService = services.Where(Function(p) p.ServiceName.ToUpperInvariant = serviceName).FirstOrDefault
                    'TODO: Should consider SystemDrivers and other type
                    If dependsOnService IsNot Nothing Then
                        rtnVal.Add(dependsOnService)
                    End If
                Next
            End Using
            _tcsServices.SetResult(rtnVal)
        Catch ex As Exception
            _tcsServices.SetResult(Nothing)
        End Try
    End Sub

    ''' <summary>
    ''' Retreive Service name from WMI Path
    ''' Example: \\Computer\root\cimv2:Win32_Service.Name="RpcSs"
    ''' </summary>
    ''' <param name="wmiPath">WMI Path</param>
    ''' <returns>String, service name</returns>
    ''' <remarks>I think there is another way to get the name, need to consider change this approach</remarks>
    Private Shared Function GetServiceName(wmiPath As String) As String
        Try
            wmiPath = wmiPath.ToUpperInvariant
            Dim pos = wmiPath.IndexOf(".Name=".ToUpperInvariant, StringComparison.Ordinal)
            Dim name = wmiPath.Substring(pos + ".Name=".Length)
            name = name.Replace("""", "")
            name = name.Replace("'", "")
            Return name
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Async Function GetDependOnThisServiceAsync(service As ServiceModel, services As List(Of ServiceModel)) As Task(Of List(Of ServiceModel))
        Try
            _tcsServices = New TaskCompletionSource(Of List(Of ServiceModel))
            Dim th As New Thread(CType(Sub() GetDependOnThisService(service, services), ThreadStart))
            th.Start()
            Dim rtnVal = Await _tcsServices.Task
            Return rtnVal
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub GetDependOnThisService(service As ServiceModel, services As List(Of ServiceModel))
        Try
            Dim queryPath = String.Format("SELECT * FROM Win32_DependentService WHERE Antecedent='Win32_Service.Name=\'{0}\''", service.ServiceName)
            Dim query As New ObjectQuery(queryPath)
            Dim manScope As New ManagementScope(String.Format(CultureInfo.InvariantCulture, "\\{0}\root\cimv2", service.SystemName))
            manScope.Options.EnablePrivileges = True

            manScope.Connect()
            Dim rtnVal As New List(Of ServiceModel)
            Using mos As ManagementObjectSearcher = New ManagementObjectSearcher(manScope, query)
                Dim queryCollection As ManagementObjectCollection = mos.Get
                'rtnVal.AddRange(From mo As ManagementObject In queryCollection Select serviceName = mo.Item("Dependent").ToString Select serviceName = GetServiceName(serviceName) Select dependsOnService = services.Where(Function(p) p.ServiceName.ToUpperInvariant = serviceName).FirstOrDefault Where dependsOnService IsNot Nothing)
                For Each mo As ManagementObject In queryCollection
                    Dim serviceName = mo.Item("Dependent").ToString
                    serviceName = GetServiceName(serviceName)
                    Dim dependsOnService = services.Where(Function(p) p.ServiceName.ToUpperInvariant = serviceName).FirstOrDefault
                    If dependsOnService IsNot Nothing Then
                        rtnVal.Add(dependsOnService)
                    End If
                Next
            End Using
            _tcsServices.SetResult(rtnVal)
        Catch ex As Exception
            _tcsServices.SetResult(Nothing)
        End Try
    End Sub

End Class
