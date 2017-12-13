# Rest.msc
Restful API management for Windows Services. Access and control windows services using http commands.

## Getting Started

- Download the latest Release binary from: [Latest Release](https://github.com/fakoua/Rest.msc/releases)
- Check the file **Rest.msc.exe.config** (Set ApiKey to empty if you want to disable the authentication)
- Run the file **Rest.msc.exe** AS ADMINISTRATOR
- From any browser open (http://localhost:9000/swagger/ui/index) to see swagger api docs (Make sure APIKey is empty)
- From any browser open (http://localhost:9000/api/Services/Get?api_key=111) to get the list of services on the machine.

## Install Rest.msc As Service

- Run the command line AS ADMINISTRATOR
- Go the Rest.msc folder and run the command **Rest.msc.exe install**
- Go to the service manager (services.msc) find the service **Rest.msc API** and Start the service
- Now you can access the API using any Restful Client
- *for complete documentation, keep reading this file!*

### Prerequisites

.Net Framework 4.7, Visual Studio 2015 or higher with Visual Basic.Net

## Authors

* **Sameh Fakoua** - [fakoua](https://github.com/fakoua)

## License

This project is licensed under the MIT License.

## API Documentation

### Authentication

**Rest.msc** supports Basic, Bearer and Query String API Key.

### Data Format

**Rest.msc** REST API provides XML and JSON as data format. The default data format is XML. 
To get a JSON result, please add “Accept application/json” to the request header. 
If you want to create a resource with JSON data format, please add “Content-Type: application/json“.

### Commands

Method | HTTP request | Description
------------- | ------------- | -------------
[**Service Details**](README.md#get-service-information) | **GET** /api/Services/Details/{serviceName} | 
[**Service Extended**](README.md#get-extended-service-information-with-dependent-services) | **GET** /api/Services/Extended/{serviceName} | 
[**Services List**](README.md#listing-services) | **GET** /api/Services/Get | 
[**Pause**](README.md#pause-a-service) | **POST** /api/Services/Pause | 
[**Resume**](README.md#resume-a-service) | **POST** /api/Services/Resume | 
[**Start**](README.md#start-a-service) | **POST** /api/Services/Start | 
[**Stop**](README.md#stop-a-service) | **POST** /api/Services/Stop | 

#### Listing Services

> **GET** http://myserver:9000/api/services

- **Payload:** none
- **Return value:** List Of ServiceModel
- **Results (JSON):**
```json
[
	{
		"ServiceName": "AGSService",
		"DisplayName": "Adobe Genuine Software Integrity Service",
		"DisplayNameDepend": "Adobe Genuine Software Integrity Service",
		"Description": "Adobe Genuine Software Integrity Service",
		"PathName": "\"C:\\Program Files...\\AGSService.exe\"",
		"AcceptPause": false,
		"AcceptStop": true,
		"DesktopInteract": false,
		"ErrorControl": "Normal",
		"IsSystem": false,
		"ProcessId": 4136,
		"ServiceType": "Own Process",
		"Started": true,
		"Status": "OK",
		"StartName": "LocalSystem",
		"State": "Running",
		"StateView": "Running",
		"SystemName": "myserver",
		"StartMode": "Auto",
		"StartModeView": "Automatic",
		"StartNameView": "LocalSystem",
		"DescriptionView": "Adobe Genuine Software Integrity Service"
	}, ...
  ...
  ...
  ]
```

#### Get Service Information

> **GET** http://myserver:9000/api/services/details/{servicename}

- **Payload:** none
- **Return value:** ServiceModel
- **Results (JSON):**

```json
{
	"ServiceName": "RpcSs",
	"DisplayName": "Remote Procedure Call (RPC)",
	"DisplayNameDepend": "Remote Procedure Call (RPC)",
	"Description": "The RPCSS service is the ... service running.",
	"PathName": "\"C:\\Windows\\system32\\svchost.exe -k rpcss\"",
	"AcceptPause": false,
	"AcceptStop": false,
	"DesktopInteract": false,
	"ErrorControl": "Normal",
	"IsSystem": false,
	"ProcessId": 816,
	"ServiceType": "Share Process",
	"Started": true,
	"Status": "OK",
	"StartName": "NT AUTHORITY\\NetworkService",
	"State": "Running",
	"StateView": "Running",
	"SystemName": "myserver",
	"StartMode": "Auto",
	"StartModeView": "Automatic",
	"StartNameView": "NetworkService",
	"DescriptionView": "The RPCSS service is the Service Control Manager f ..."
}
```

#### Get Extended Service Information (With dependent services)

> **GET** http://myserver:9000/api/services/extended/{servicename}

- **Payload:** none
- **Return value:** ExtendedServiceModel
- **Results (JSON):**

```json
{
	"Service": {
		"ServiceName": "RpcSs",
		"DisplayName": "Remote Procedure Call (RPC)",
		"DisplayNameDepend": "Remote Procedure Call (RPC)",
		"Description": "The RPCSS service is the Service ... the RPCSS service running.",
		"PathName": "\"C:\\Windows\\system32\\svchost.exe -k rpcss\"",
		"AcceptPause": false,
		"AcceptStop": false,
		"DesktopInteract": false,
		"ErrorControl": "Normal",
		"IsSystem": false,
		"ProcessId": 816,
		"ServiceType": "Share Process",
		"Started": true,
		"Status": "OK",
		"StartName": "NT AUTHORITY\\NetworkService",
		"State": "Running",
		"StateView": "Running",
		"SystemName": "myserver",
		"StartMode": "Auto",
		"StartModeView": "Automatic",
		"StartNameView": "NetworkService",
		"DescriptionView": "The RPCSS service is the  ..."
	},
	"DependsOn": [
		{
			"ServiceName": "RpcEptMapper",
			"DisplayName": "RPC Endpoint Mapper",
			"DisplayNameDepend": "RPC Endpoint Mapper",
			"Description": "Resolves RPC interfaces ... properly.",
			"PathName": "\"C:\\Windows\\system32\\svchost.exe -k RPCSS\"",
			"AcceptPause": false,
			"AcceptStop": false,
			"DesktopInteract": false,
			"ErrorControl": "Normal",
			"IsSystem": false,
			"ProcessId": 816,
			"ServiceType": "Share Process",
			"Started": true,
			"Status": "OK",
			"StartName": "NT AUTHORITY\\NetworkService",
			"State": "Running",
			"StateView": "Running",
			"SystemName": "myserver",
			"StartMode": "Auto",
			"StartModeView": "Automatic",
			"StartNameView": "NetworkService",
			"DescriptionView": "Resolves RPC interfaces identifiers to transport e ..."
		},
		{
			"ServiceName": "DcomLaunch",
			"DisplayName": "DCOM Server Process Launcher",
			"DisplayNameDepend": "DCOM Server Process Launcher",
			"Description": "The DCOMLAUNCH service ... running.",
			"PathName": "\"C:\\Windows\\system32\\svchost.exe -k DcomLaunch\"",
			"AcceptPause": false,
			"AcceptStop": false,
			"DesktopInteract": false,
			"ErrorControl": "Normal",
			"IsSystem": false,
			"ProcessId": 752,
			"ServiceType": "Share Process",
			"Started": true,
			"Status": "OK",
			"StartName": "LocalSystem",
			"State": "Running",
			"StateView": "Running",
			"SystemName": "myserver",
			"StartMode": "Auto",
			"StartModeView": "Automatic",
			"StartNameView": "LocalSystem",
			"DescriptionView": "The DCOMLAUNCH service launches COM and DCOM serve ..."
		}
	],
	"DependOnThisService": []
}
```

#### Start a service

> **POST** http://myserver:9000/api/services/start

- **Payload:** service name
```json
{
	"serviceName": "myservice"
}
```
- **Return value:** String (WMI Action Result)
- **Results (String):**
``` Success ```

#### Stop a service

> **POST** http://myserver:9000/api/services/stop

- **Payload:** service name
```json
{
	"serviceName": "myservice"
}
```
- **Return value:** String (WMI Action Result)
- **Results (String):**
``` Success ```

#### Pause a service

> **POST** http://myserver:9000/api/services/pause

- **Payload:** service name
```json
{
	"serviceName": "myservice"
}
```
- **Return value:** String (WMI Action Result)
- **Results (String):**
``` Success ```

#### Resume a service

> **POST** http://myserver:9000/api/services/resume

- **Payload:** service name
```json
{
	"serviceName": "myservice"
}
```
- **Return value:** String (WMI Action Result)
- **Results (String):**
``` Success ```


## Object Model:

### WMI Action Result

```vbnet
    Success
    NotSupported
    AccessDenied
    DependentServicesRunning
    InvalidServiceControl
    ServiceCannotAcceptControl
    ServiceNotActive
    ServiceRequestTimeout
    UnknownFailure
    PathNotFound
    ServiceAlreadyRunning
    ServiceDatabaseLocked
    ServiceDependencyDeleted
    ServiceDependencyFailure
    ServiceDisabled
    ServiceLogonFailure
    ServiceMarkedForDeletion
    ServiceNoThread
    StatusCircularDependency
    StatusDuplicateName
    StatusInvalidName
    StatusInvalidParameter
    StatusInvalidServiceAccount
    StatusServiceExists
    ServiceAlreadyPaused
    ServiceNotFound
    HandledError
 ```
 
 ### Service Model
 ```vbnet
 Public Class ServiceModel
    Property ServiceName As String
    Property DisplayName As String
    Property Description As String
    Property PathName As String
    Property AcceptPause As Boolean
    Property AcceptStop As Boolean
    Property DesktopInteract As Boolean
    Property ErrorControl As String
    Property IsSystem As Boolean
    Property ProcessId As UInt32
    Property ServiceType As String
    Property Started As Boolean
    Property Status As String
    Property StartName As String
    Property State As String
    ReadOnly Property StateView As String
    Property SystemName As String
    Property StartMode As String
    Public ReadOnly Property StartModeView As String
    Public ReadOnly Property StartNameView As String
    Public ReadOnly Property DescriptionView As String
End Class

 ```
