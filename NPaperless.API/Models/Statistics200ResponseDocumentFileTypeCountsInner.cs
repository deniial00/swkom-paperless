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
using NPaperless.API.Converters;

namespace NPaperless.API.DTOs
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Statistics200ResponseDocumentFileTypeCountsInner 
    {
        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [Required]
        [DataMember(Name="mime_type", EmitDefaultValue=false)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets MimeTypeCount
        /// </summary>
        [Required]
        [DataMember(Name="mime_type_count", EmitDefaultValue=true)]
        public int MimeTypeCount { get; set; }

    }
}
