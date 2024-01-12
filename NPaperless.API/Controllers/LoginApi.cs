/*
 * Paperless Rest Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NPaperless.API.Attributes;
using NPaperless.API.DTOs;
using NPaperless.BL.Interfaces;

namespace NPaperless.API.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    { 

		private readonly ILoginApiLogic _logic;

		public LoginApiController(ILoginApiLogic logic)
		{
			_logic = logic;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/")]
        [ValidateModelState]
        [SwaggerOperation("ApiGet")]
        public virtual IActionResult ApiGet()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createGroupRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/groups/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Success")]
        public virtual IActionResult CreateGroup([FromBody]CreateGroupRequest createGroupRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Object));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/users/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200ResponseResultsInner), description: "Success")]
        public virtual IActionResult CreateUser([FromBody]CreateUserRequest createUserRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetUsers200ResponseResultsInner));
            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200ResponseResultsInner>(exampleJson)
            : default(GetUsers200ResponseResultsInner);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/groups/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteGroup")]
        public virtual IActionResult DeleteGroup([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/users/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        public virtual IActionResult DeleteUser([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/groups/")]
        [ValidateModelState]
        [SwaggerOperation("GetGroups")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetGroups200Response), description: "Success")]
        public virtual IActionResult GetGroups([FromQuery (Name = "page")]int? page, [FromQuery (Name = "page_size")]int? pageSize)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetGroups200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ \"\", \"\" ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ \"\", \"\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetGroups200Response>(exampleJson)
            : default(GetGroups200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfo"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/token/")]
        [Consumes("application/json", "text/json", "application/*+json")]
        [ValidateModelState]
        [SwaggerOperation("GetToken")]
        public virtual IActionResult GetToken([FromBody]UserInfo userInfo)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/users/")]
        [ValidateModelState]
        [SwaggerOperation("GetUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200Response), description: "Success")]
        public virtual IActionResult GetUsers([FromQuery (Name = "page")]int? page, [FromQuery (Name = "page_size")]int? pageSize)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetUsers200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  }, {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200Response>(exampleJson)
            : default(GetUsers200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/")]
        [ValidateModelState]
        [SwaggerOperation("Root")]
        public virtual IActionResult Root()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/statistics/")]
        [ValidateModelState]
        [SwaggerOperation("Statistics")]
        [SwaggerResponse(statusCode: 200, type: typeof(Statistics200Response), description: "Success")]
        public virtual IActionResult Statistics()
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Statistics200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"document_file_type_counts\" : [ {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  }, {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  } ],\n  \"documents_inbox\" : 6,\n  \"inbox_tag\" : 1,\n  \"documents_total\" : 0,\n  \"character_count\" : 5\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Statistics200Response>(exampleJson)
            : default(Statistics200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateGroupRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/groups/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateGroup200Response), description: "Success")]
        public virtual IActionResult UpdateGroup([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateGroupRequest updateGroupRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UpdateGroup200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"name\" : \"name\",\n  \"id\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<UpdateGroup200Response>(exampleJson)
            : default(UpdateGroup200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/users/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetUsers200ResponseResultsInner), description: "Success")]
        public virtual IActionResult UpdateUser([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateUserRequest updateUserRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetUsers200ResponseResultsInner));
            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetUsers200ResponseResultsInner>(exampleJson)
            : default(GetUsers200ResponseResultsInner);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
