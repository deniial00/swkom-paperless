using NPaperless.BL.Entities;
using NPaperless.API.DTOs;
using AutoMapper;

namespace NPaperless.API
{
    /// <summary>
    /// AutoMapperProfile
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoMapperProfile() 
        {
            CreateMap<NPaperless.BL.Entities.Correspondent, NPaperless.API.DTOs.Correspondent>();
            CreateMap<NPaperless.BL.Entities.Document, NPaperless.API.DTOs.Document>();
            CreateMap<NPaperless.BL.Entities.DocumentType, NPaperless.API.DTOs.DocumentType>();
            CreateMap<NPaperless.BL.Entities.UserInfo, NPaperless.API.DTOs.UserInfo>();
            CreateMap<NPaperless.BL.Entities.DocTag, NPaperless.API.DTOs.DocTag>();        
        }
    }
}