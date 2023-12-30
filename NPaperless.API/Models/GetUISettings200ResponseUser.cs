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
    public partial class GetUISettings200ResponseUser 
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id", EmitDefaultValue=true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [Required]
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets IsSuperuser
        /// </summary>
        [Required]
        [DataMember(Name="is_superuser", EmitDefaultValue=true)]
        public bool IsSuperuser { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [Required]
        [DataMember(Name="groups", EmitDefaultValue=false)]
        public List<Object> Groups { get; set; }

    }
}
