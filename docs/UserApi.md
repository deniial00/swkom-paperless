# Org.OpenAPITools.Api.UserApi

All URIs are relative to *https://raw.githubusercontent.com/v3*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateUser**](UserApi.md#createuser) | **POST** /user | Create user |
| [**CreateUsersWithListInput**](UserApi.md#createuserswithlistinput) | **POST** /user/createWithList | Creates list of users with given input array |
| [**DeleteUser**](UserApi.md#deleteuser) | **DELETE** /user/{username} | Delete user |
| [**GetUserByName**](UserApi.md#getuserbyname) | **GET** /user/{username} | Get user by user name |
| [**LoginUser**](UserApi.md#loginuser) | **GET** /user/login | Logs user into the system |
| [**LogoutUser**](UserApi.md#logoutuser) | **GET** /user/logout | Logs out current logged in user session |
| [**UpdateUser**](UserApi.md#updateuser) | **PUT** /user/{username} | Update user |

<a id="createuser"></a>
# **CreateUser**
> User CreateUser (User? user = null)

Create user

This can only be done by the logged in user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var user = new User?(); // User? | Created user object (optional) 

            try
            {
                // Create user
                User result = apiInstance.CreateUser(user);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.CreateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create user
    ApiResponse<User> response = apiInstance.CreateUserWithHttpInfo(user);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.CreateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **user** | [**User?**](User?.md) | Created user object | [optional]  |

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, application/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **0** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="createuserswithlistinput"></a>
# **CreateUsersWithListInput**
> User CreateUsersWithListInput (List<User>? user = null)

Creates list of users with given input array

Creates list of users with given input array

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class CreateUsersWithListInputExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var user = new List<User>?(); // List<User>? |  (optional) 

            try
            {
                // Creates list of users with given input array
                User result = apiInstance.CreateUsersWithListInput(user);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.CreateUsersWithListInput: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateUsersWithListInputWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Creates list of users with given input array
    ApiResponse<User> response = apiInstance.CreateUsersWithListInputWithHttpInfo(user);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.CreateUsersWithListInputWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **user** | [**List&lt;User&gt;?**](User.md) |  | [optional]  |

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **0** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deleteuser"></a>
# **DeleteUser**
> void DeleteUser (string username)

Delete user

This can only be done by the logged in user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var username = "username_example";  // string | The name that needs to be deleted

            try
            {
                // Delete user
                apiInstance.DeleteUser(username);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.DeleteUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete user
    apiInstance.DeleteUserWithHttpInfo(username);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.DeleteUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name that needs to be deleted |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **400** | Invalid username supplied |  -  |
| **404** | User not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getuserbyname"></a>
# **GetUserByName**
> User GetUserByName (string username)

Get user by user name

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetUserByNameExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var username = "username_example";  // string | The name that needs to be fetched. Use user1 for testing. 

            try
            {
                // Get user by user name
                User result = apiInstance.GetUserByName(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.GetUserByName: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUserByNameWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get user by user name
    ApiResponse<User> response = apiInstance.GetUserByNameWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.GetUserByNameWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name that needs to be fetched. Use user1 for testing.  |  |

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Invalid username supplied |  -  |
| **404** | User not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="loginuser"></a>
# **LoginUser**
> string LoginUser (string? username = null, string? password = null)

Logs user into the system

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class LoginUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var username = "username_example";  // string? | The user name for login (optional) 
            var password = "password_example";  // string? | The password for login in clear text (optional) 

            try
            {
                // Logs user into the system
                string result = apiInstance.LoginUser(username, password);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.LoginUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the LoginUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Logs user into the system
    ApiResponse<string> response = apiInstance.LoginUserWithHttpInfo(username, password);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.LoginUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string?** | The user name for login | [optional]  |
| **password** | **string?** | The password for login in clear text | [optional]  |

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  * X-Rate-Limit - calls per hour allowed by the user <br>  * X-Expires-After - date in UTC when token expires <br>  |
| **400** | Invalid username/password supplied |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="logoutuser"></a>
# **LogoutUser**
> void LogoutUser ()

Logs out current logged in user session

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class LogoutUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);

            try
            {
                // Logs out current logged in user session
                apiInstance.LogoutUser();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.LogoutUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the LogoutUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Logs out current logged in user session
    apiInstance.LogoutUserWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.LogoutUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **0** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateuser"></a>
# **UpdateUser**
> void UpdateUser (string username, User? user = null)

Update user

This can only be done by the logged in user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class UpdateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://raw.githubusercontent.com/v3";
            var apiInstance = new UserApi(config);
            var username = "username_example";  // string | name that needs to be updated
            var user = new User?(); // User? | Update an existent user in the store (optional) 

            try
            {
                // Update user
                apiInstance.UpdateUser(username, user);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserApi.UpdateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update user
    apiInstance.UpdateUserWithHttpInfo(username, user);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserApi.UpdateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | name that needs to be updated |  |
| **user** | [**User?**](User?.md) | Update an existent user in the store | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, application/xml, application/x-www-form-urlencoded
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **0** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

