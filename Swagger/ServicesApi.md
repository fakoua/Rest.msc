# IO.Swagger.Api.ServicesApi

All URIs are relative to *http://localhost:9000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ServicesDetails**](ServicesApi.md#servicesdetails) | **GET** /api/Services/Details/{serviceName} | 
[**ServicesExtended**](ServicesApi.md#servicesextended) | **GET** /api/Services/Extended/{serviceName} | 
[**ServicesGet**](ServicesApi.md#servicesget) | **GET** /api/Services/Get | 
[**ServicesPause**](ServicesApi.md#servicespause) | **POST** /api/Services/Pause | 
[**ServicesResume**](ServicesApi.md#servicesresume) | **POST** /api/Services/Resume | 
[**ServicesStart**](ServicesApi.md#servicesstart) | **POST** /api/Services/Start | 
[**ServicesStop**](ServicesApi.md#servicesstop) | **POST** /api/Services/Stop | 


<a name="servicesdetails"></a>
# **ServicesDetails**
> ServiceModel ServicesDetails (string serviceName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesDetailsExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var serviceName = serviceName_example;  // string | 

            try
            {
                ServiceModel result = apiInstance.ServicesDetails(serviceName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesDetails: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceName** | **string**|  | 

### Return type

[**ServiceModel**](ServiceModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicesextended"></a>
# **ServicesExtended**
> ExtendedServiceModel ServicesExtended (string serviceName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesExtendedExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var serviceName = serviceName_example;  // string | 

            try
            {
                ExtendedServiceModel result = apiInstance.ServicesExtended(serviceName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesExtended: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **serviceName** | **string**|  | 

### Return type

[**ExtendedServiceModel**](ExtendedServiceModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicesget"></a>
# **ServicesGet**
> List<ServiceModel> ServicesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesGetExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();

            try
            {
                List&lt;ServiceModel&gt; result = apiInstance.ServicesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<ServiceModel>**](ServiceModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicespause"></a>
# **ServicesPause**
> string ServicesPause (ServiceModel service)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesPauseExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var service = new ServiceModel(); // ServiceModel | 

            try
            {
                string result = apiInstance.ServicesPause(service);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesPause: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **service** | [**ServiceModel**](ServiceModel.md)|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicesresume"></a>
# **ServicesResume**
> string ServicesResume (ServiceModel service)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesResumeExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var service = new ServiceModel(); // ServiceModel | 

            try
            {
                string result = apiInstance.ServicesResume(service);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesResume: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **service** | [**ServiceModel**](ServiceModel.md)|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicesstart"></a>
# **ServicesStart**
> string ServicesStart (ServiceModel service)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesStartExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var service = new ServiceModel(); // ServiceModel | 

            try
            {
                string result = apiInstance.ServicesStart(service);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesStart: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **service** | [**ServiceModel**](ServiceModel.md)|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="servicesstop"></a>
# **ServicesStop**
> string ServicesStop (ServiceModel service)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ServicesStopExample
    {
        public void main()
        {
            var apiInstance = new ServicesApi();
            var service = new ServiceModel(); // ServiceModel | 

            try
            {
                string result = apiInstance.ServicesStop(service);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServicesApi.ServicesStop: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **service** | [**ServiceModel**](ServiceModel.md)|  | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

