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
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NPaperless.Services.Converters;

namespace NPaperless.Services.DTOs
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GetDocuments200ResponseResultsInnerNotesInner 
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [Required]
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [Required]
        [DataMember(Name="created", EmitDefaultValue=false)]
        public string Created { get; set; }

        /// <summary>
        /// Gets or Sets Document
        /// </summary>
        [Required]
        [DataMember(Name="document", EmitDefaultValue=true)]
        public int Document { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [Required]
        [DataMember(Name="user", EmitDefaultValue=true)]
        public int User { get; set; }

    }
}
