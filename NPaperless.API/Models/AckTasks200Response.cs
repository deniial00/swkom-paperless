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
using PaperLessApi.Converters;

namespace PaperLessApi.DTOs
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AckTasks200Response 
    {
        /// <summary>
        /// Gets or Sets Result
        /// </summary>
        [Required]
        [DataMember(Name="result", EmitDefaultValue=true)]
        public int Result { get; set; }

    }
}
