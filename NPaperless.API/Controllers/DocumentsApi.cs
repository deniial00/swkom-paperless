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
using AutoMapper;
using System.Threading.Tasks;
using NPaperless.BL.Entities;
using System.Security;
using Microsoft.Extensions.Logging;

namespace NPaperless.API.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DocumentsApiController : ControllerBase
    { 

		private readonly IMapper _mapper;
		private readonly IDocumentLogic _logic;
		private readonly ILogger<DocumentsApiController> _logger;
		public DocumentsApiController(IMapper mapper, IDocumentLogic logic, ILogger<DocumentsApiController> logger)
		{
			_mapper = mapper;
			_logic = logic;
			_logger = logger;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulkEditRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/bulk_edit/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("BulkEdit")]
        public virtual IActionResult BulkEdit([FromBody]BulkEditRequest bulkEditRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/documents/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("DeleteDocument")]
        public virtual IActionResult DeleteDocument([FromRoute (Name = "id")][Required]int id)
        {
			_logger.Log(LogLevel.Debug, "Called delete document route with document id '" + id + "'");
			var result = _logic.DeleteDocument(id);
        	return result == null ? StatusCode(500) : Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="original"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/download/")]
        [ValidateModelState]
        [SwaggerOperation("DownloadDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult DownloadDocument([FromRoute (Name = "id")][Required]int id, [FromQuery (Name = "original")]bool? original)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocument200Response), description: "Success")]
        public virtual IActionResult GetDocument([FromRoute (Name = "id")][Required]int id, [FromQuery (Name = "page")]int? page, [FromQuery (Name = "full_perms")]bool? fullPerms)
        {
			_logger.Log(LogLevel.Debug, "Called get document route with document id '" + id + "'");
            // result = "{\n  \"owner\" : 7,\n  \"archive_serial_number\" : 2,\n  \"notes\" : [ {\n    \"note\" : \"note\",\n    \"created\" : \"created\",\n    \"document\" : 1,\n    \"id\" : 7,\n    \"user\" : 1\n  }, {\n    \"note\" : \"note\",\n    \"created\" : \"created\",\n    \"document\" : 1,\n    \"id\" : 7,\n    \"user\" : 1\n  } ],\n  \"added\" : \"added\",\n  \"created\" : \"created\",\n  \"title\" : \"title\",\n  \"content\" : \"content\",\n  \"tags\" : [ 5, 5 ],\n  \"storage_path\" : 5,\n  \"permissions\" : {\n    \"view\" : {\n      \"groups\" : [ 3, 3 ],\n      \"users\" : [ 9, 9 ]\n    },\n    \"change\" : {\n      \"groups\" : [ 3, 3 ],\n      \"users\" : [ 9, 9 ]\n    }\n  },\n  \"archived_file_name\" : \"archived_file_name\",\n  \"modified\" : \"modified\",\n  \"correspondent\" : 6,\n  \"original_file_name\" : \"original_file_name\",\n  \"id\" : 0,\n  \"created_date\" : \"created_date\",\n  \"document_type\" : 1\n}";
			var result = _logic.GetDocument(id, page, fullPerms);
        	return result == null ? StatusCode(500) : Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/metadata/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentMetadata")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocumentMetadata200Response), description: "Success")]
        public virtual IActionResult GetDocumentMetadata([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocumentMetadata200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"archive_size\" : 6,\n  \"archive_metadata\" : [ {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  }, {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  } ],\n  \"original_metadata\" : [ \"\", \"\" ],\n  \"original_filename\" : \"original_filename\",\n  \"original_mime_type\" : \"original_mime_type\",\n  \"archive_checksum\" : \"archive_checksum\",\n  \"original_checksum\" : \"original_checksum\",\n  \"lang\" : \"lang\",\n  \"media_filename\" : \"media_filename\",\n  \"has_archive_version\" : true,\n  \"archive_media_filename\" : \"archive_media_filename\",\n  \"original_size\" : 0\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocumentMetadata200Response>(exampleJson)
            : default(GetDocumentMetadata200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/preview/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentPreview")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult GetDocumentPreview([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/suggestions/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentSuggestions")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocumentSuggestions200Response), description: "Success")]
        public virtual IActionResult GetDocumentSuggestions([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocumentSuggestions200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"storage_paths\" : [ \"\", \"\" ],\n  \"document_types\" : [ \"\", \"\" ],\n  \"dates\" : [ \"\", \"\" ],\n  \"correspondents\" : [ \"\", \"\" ],\n  \"tags\" : [ \"\", \"\" ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocumentSuggestions200Response>(exampleJson)
            : default(GetDocumentSuggestions200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/thumb/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentThumb")]
        [SwaggerResponse(statusCode: 200, type: typeof(System.IO.Stream), description: "Success")]
        public virtual IActionResult GetDocumentThumb([FromRoute (Name = "id")][Required]int id)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(System.IO.Stream));
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<System.IO.Stream>(exampleJson)
            : default(System.IO.Stream);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="query"></param>
        /// <param name="ordering"></param>
        /// <param name="tagsIdAll"></param>
        /// <param name="documentTypeId"></param>
        /// <param name="storagePathIdIn"></param>
        /// <param name="correspondentId"></param>
        /// <param name="truncateContent"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/")]
        [ValidateModelState]
        [SwaggerOperation("GetDocuments")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetDocuments200Response), description: "Success")]
        public virtual IActionResult GetDocuments([FromQuery (Name = "Page")]int? page, [FromQuery (Name = "page_size")]int? pageSize, [FromQuery (Name = "query")]string query, [FromQuery (Name = "ordering")]string ordering, [FromQuery (Name = "tags__id__all")]List<int> tagsIdAll, [FromQuery (Name = "document_type__id")]int? documentTypeId, [FromQuery (Name = "storage_path__id__in")]int? storagePathIdIn, [FromQuery (Name = "correspondent__id")]int? correspondentId, [FromQuery (Name = "truncate_content")]bool? truncateContent)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GetDocuments200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  }, {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GetDocuments200Response>(exampleJson)
            : default(GetDocuments200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectionDataRequest"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/selection_data/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("SelectionData")]
        [SwaggerResponse(statusCode: 200, type: typeof(SelectionData200Response), description: "Success")]
        public virtual IActionResult SelectionData([FromBody]SelectionDataRequest selectionDataRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(SelectionData200Response));
            string exampleJson = null;
            exampleJson = "{\n  \"selected_storage_paths\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_document_types\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_correspondents\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_tags\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ]\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<SelectionData200Response>(exampleJson)
            : default(SelectionData200Response);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDocumentRequest"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/documents/{id}/")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(UpdateDocument200Response), description: "Success")]
        public virtual IActionResult UpdateDocument([FromRoute (Name = "id")][Required]int id, [FromBody]UpdateDocumentRequest updateDocumentRequest)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(UpdateDocument200Response));
            // string exampleJson = null;
            // exampleJson = "{\n  \"owner\" : 7,\n  \"user_can_change\" : true,\n  \"archive_serial_number\" : 2,\n  \"notes\" : [ \"\", \"\" ],\n  \"added\" : \"added\",\n  \"created\" : \"created\",\n  \"title\" : \"title\",\n  \"content\" : \"content\",\n  \"tags\" : [ 5, 5 ],\n  \"storage_path\" : 5,\n  \"archived_file_name\" : \"archived_file_name\",\n  \"modified\" : \"modified\",\n  \"correspondent\" : 6,\n  \"original_file_name\" : \"original_file_name\",\n  \"id\" : 0,\n  \"created_date\" : \"created_date\",\n  \"document_type\" : 1\n}";
            
            // var example = exampleJson != null
            // ? JsonConvert.DeserializeObject<UpdateDocument200Response>(exampleJson)
            // : default(UpdateDocument200Response);
            // //TODO: Change the data returned
            // return new ObjectResult(example);

			// todo: richtige parameter übergeben und schauen, wie das überhaupt funktionieren soll
			_logger.Log(LogLevel.Debug, "Called update document route with document id '" + id + "'");
			var result = _logic.UpdateDocument();
			return result == null ? StatusCode(500) : Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="created"></param>
        /// <param name="documentType"></param>
        /// <param name="tags"></param>
        /// <param name="correspondent"></param>
        /// <param name="documentFile"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/post_document/")]
        [Consumes("multipart/form-data")]
        [ValidateModelState]
        [SwaggerOperation("UploadDocument")]
		public virtual async Task<IActionResult> UploadDocumentAsync([FromForm (Name = "title")]string title, [FromForm (Name = "created")]DateTime created, [FromForm (Name = "document_type")]int documentType, [FromForm (Name = "tags")]List<int> tags, [FromForm (Name = "correspondent")]int correspondent, [FromForm (Name = "document")]IEnumerable<IFormFile> documentFile)
		{
			_logger.Log(LogLevel.Debug, "Called upload document route");
			var newDocument = new NPaperless.BL.Entities.Document
			{
				Title = title,
				Created = created,
				DocumentType = documentType,
				Tags = tags,
				Correspondent = correspondent
			};

			var result = await _logic.CreateDocument(newDocument, documentFile);
			return !result ? StatusCode(500) : Ok(result);
		}
    }
}
