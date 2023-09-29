/*
 * Swagger Petstore - OpenAPI 3.0
 *
 * This is a sample Pet Store Server based on the OpenAPI 3.0 specification.  You can find out more about Swagger at [http://swagger.io](http://swagger.io). In the third iteration of the pet store, we've switched to the design first approach! You can now help us improve the API whether it's by making changes to the definition itself or to the code. That way, with time, we can improve the API in general, and expose some of the new features in OAS3.  Some useful links: - [The Pet Store repository](https://github.com/swagger-api/swagger-petstore) - [The source API definition for the Pet Store](https://github.com/swagger-api/swagger-petstore/blob/master/src/main/resources/openapi.yaml)
 *
 * The version of the OpenAPI document: 1.0.17
 * Contact: apiteam@swagger.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing UserApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class UserApiTests : IDisposable
    {
        private UserApi instance;

        public UserApiTests()
        {
            instance = new UserApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of UserApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' UserApi
            //Assert.IsType<UserApi>(instance);
        }

        /// <summary>
        /// Test CreateUser
        /// </summary>
        [Fact]
        public void CreateUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //User? user = null;
            //var response = instance.CreateUser(user);
            //Assert.IsType<User>(response);
        }

        /// <summary>
        /// Test CreateUsersWithListInput
        /// </summary>
        [Fact]
        public void CreateUsersWithListInputTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //List<User>? user = null;
            //var response = instance.CreateUsersWithListInput(user);
            //Assert.IsType<User>(response);
        }

        /// <summary>
        /// Test DeleteUser
        /// </summary>
        [Fact]
        public void DeleteUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //instance.DeleteUser(username);
        }

        /// <summary>
        /// Test GetUserByName
        /// </summary>
        [Fact]
        public void GetUserByNameTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //var response = instance.GetUserByName(username);
            //Assert.IsType<User>(response);
        }

        /// <summary>
        /// Test LoginUser
        /// </summary>
        [Fact]
        public void LoginUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string? username = null;
            //string? password = null;
            //var response = instance.LoginUser(username, password);
            //Assert.IsType<string>(response);
        }

        /// <summary>
        /// Test LogoutUser
        /// </summary>
        [Fact]
        public void LogoutUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //instance.LogoutUser();
        }

        /// <summary>
        /// Test UpdateUser
        /// </summary>
        [Fact]
        public void UpdateUserTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string username = null;
            //User? user = null;
            //instance.UpdateUser(username, user);
        }
    }
}
