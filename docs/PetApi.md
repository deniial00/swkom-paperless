# Org.OpenAPITools.Api.PetApi

All URIs are relative to *https://raw.githubusercontent.com/v3*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddPet**](PetApi.md#addpet) | **POST** /pet | Add a new pet to the store |
| [**DeletePet**](PetApi.md#deletepet) | **DELETE** /pet/{petId} | Deletes a pet |
| [**FindPetsByStatus**](PetApi.md#findpetsbystatus) | **GET** /pet/findByStatus | Finds Pets by status |
| [**FindPetsByTags**](PetApi.md#findpetsbytags) | **GET** /pet/findByTags | Finds Pets by tags |
| [**GetPetById**](PetApi.md#getpetbyid) | **GET** /pet/{petId} | Find pet by ID |
| [**UpdatePet**](PetApi.md#updatepet) | **PUT** /pet | Update an existing pet |
| [**UpdatePetWithForm**](PetApi.md#updatepetwithform) | **POST** /pet/{petId} | Updates a pet in the store with form data |
| [**UploadFile**](PetApi.md#uploadfile) | **POST** /pet/{petId}/uploadImage | uploads an image |

<a id="addpet"></a>
# **AddPet**
> Pet AddPet (Pet pet)

Add a new pet to the store

Add a new pet to the store

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class AddPetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var pet = new Pet(); // Pet | Create a new pet in the store

            try
            {
                // Add a new pet to the store
                Pet result = apiInstance.AddPet(pet);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.AddPet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddPetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add a new pet to the store
    ApiResponse<Pet> response = apiInstance.AddPetWithHttpInfo(pet);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.AddPetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pet** | [**Pet**](Pet.md) | Create a new pet in the store |  |

### Return type

[**Pet**](Pet.md)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/xml, application/x-www-form-urlencoded
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **405** | Invalid input |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletepet"></a>
# **DeletePet**
> void DeletePet (long petId, string? apiKey = null)

Deletes a pet

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeletePetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var petId = 789L;  // long | Pet id to delete
            var apiKey = "apiKey_example";  // string? |  (optional) 

            try
            {
                // Deletes a pet
                apiInstance.DeletePet(petId, apiKey);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.DeletePet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeletePetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Deletes a pet
    apiInstance.DeletePetWithHttpInfo(petId, apiKey);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.DeletePetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **petId** | **long** | Pet id to delete |  |
| **apiKey** | **string?** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Invalid pet value |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="findpetsbystatus"></a>
# **FindPetsByStatus**
> List&lt;Pet&gt; FindPetsByStatus (string? status = null)

Finds Pets by status

Multiple status values can be provided with comma separated strings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class FindPetsByStatusExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var status = "available";  // string? | Status values that need to be considered for filter (optional)  (default to available)

            try
            {
                // Finds Pets by status
                List<Pet> result = apiInstance.FindPetsByStatus(status);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.FindPetsByStatus: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindPetsByStatusWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Finds Pets by status
    ApiResponse<List<Pet>> response = apiInstance.FindPetsByStatusWithHttpInfo(status);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.FindPetsByStatusWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **status** | **string?** | Status values that need to be considered for filter | [optional] [default to available] |

### Return type

[**List&lt;Pet&gt;**](Pet.md)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Invalid status value |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="findpetsbytags"></a>
# **FindPetsByTags**
> List&lt;Pet&gt; FindPetsByTags (List<string>? tags = null)

Finds Pets by tags

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class FindPetsByTagsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var tags = new List<string>?(); // List<string>? | Tags to filter by (optional) 

            try
            {
                // Finds Pets by tags
                List<Pet> result = apiInstance.FindPetsByTags(tags);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.FindPetsByTags: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FindPetsByTagsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Finds Pets by tags
    ApiResponse<List<Pet>> response = apiInstance.FindPetsByTagsWithHttpInfo(tags);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.FindPetsByTagsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tags** | [**List&lt;string&gt;?**](string.md) | Tags to filter by | [optional]  |

### Return type

[**List&lt;Pet&gt;**](Pet.md)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Invalid tag value |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getpetbyid"></a>
# **GetPetById**
> Pet GetPetById (long petId)

Find pet by ID

Returns a single pet

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetPetByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure API key authorization: api_key
            config.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new PetApi(config);
            var petId = 789L;  // long | ID of pet to return

            try
            {
                // Find pet by ID
                Pet result = apiInstance.GetPetById(petId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.GetPetById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPetByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Find pet by ID
    ApiResponse<Pet> response = apiInstance.GetPetByIdWithHttpInfo(petId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.GetPetByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **petId** | **long** | ID of pet to return |  |

### Return type

[**Pet**](Pet.md)

### Authorization

[petstore_auth](../README.md#petstore_auth), [api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Invalid ID supplied |  -  |
| **404** | Pet not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatepet"></a>
# **UpdatePet**
> Pet UpdatePet (Pet pet)

Update an existing pet

Update an existing pet by Id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdatePetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var pet = new Pet(); // Pet | Update an existent pet in the store

            try
            {
                // Update an existing pet
                Pet result = apiInstance.UpdatePet(pet);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.UpdatePet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an existing pet
    ApiResponse<Pet> response = apiInstance.UpdatePetWithHttpInfo(pet);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.UpdatePetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pet** | [**Pet**](Pet.md) | Update an existent pet in the store |  |

### Return type

[**Pet**](Pet.md)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/xml, application/x-www-form-urlencoded
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **400** | Invalid ID supplied |  -  |
| **404** | Pet not found |  -  |
| **405** | Validation exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatepetwithform"></a>
# **UpdatePetWithForm**
> void UpdatePetWithForm (long petId, string? name = null, string? status = null)

Updates a pet in the store with form data

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdatePetWithFormExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var petId = 789L;  // long | ID of pet that needs to be updated
            var name = "name_example";  // string? | Name of pet that needs to be updated (optional) 
            var status = "status_example";  // string? | Status of pet that needs to be updated (optional) 

            try
            {
                // Updates a pet in the store with form data
                apiInstance.UpdatePetWithForm(petId, name, status);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.UpdatePetWithForm: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePetWithFormWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Updates a pet in the store with form data
    apiInstance.UpdatePetWithFormWithHttpInfo(petId, name, status);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.UpdatePetWithFormWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **petId** | **long** | ID of pet that needs to be updated |  |
| **name** | **string?** | Name of pet that needs to be updated | [optional]  |
| **status** | **string?** | Status of pet that needs to be updated | [optional]  |

### Return type

void (empty response body)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Invalid input |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadfile"></a>
# **UploadFile**
> ApiResponse UploadFile (long petId, string? additionalMetadata = null, System.IO.Stream? body = null)

uploads an image

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UploadFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            // Configure OAuth2 access token for authorization: petstore_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PetApi(config);
            var petId = 789L;  // long | ID of pet to update
            var additionalMetadata = "additionalMetadata_example";  // string? | Additional Metadata (optional) 
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? |  (optional) 

            try
            {
                // uploads an image
                ApiResponse result = apiInstance.UploadFile(petId, additionalMetadata, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PetApi.UploadFile: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadFileWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // uploads an image
    ApiResponse<ApiResponse> response = apiInstance.UploadFileWithHttpInfo(petId, additionalMetadata, body);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PetApi.UploadFileWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **petId** | **long** | ID of pet to update |  |
| **additionalMetadata** | **string?** | Additional Metadata | [optional]  |
| **body** | **System.IO.Stream?****System.IO.Stream?** |  | [optional]  |

### Return type

[**ApiResponse**](ApiResponse.md)

### Authorization

[petstore_auth](../README.md#petstore_auth)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

