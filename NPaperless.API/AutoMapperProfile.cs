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

			CreateMap<NPaperless.DA.Entities.Correspondent, NPaperless.BL.Entities.Correspondent>();
            CreateMap<NPaperless.DA.Entities.Document, NPaperless.BL.Entities.Document>();
            CreateMap<NPaperless.DA.Entities.DocumentType, NPaperless.BL.Entities.DocumentType>();
            CreateMap<NPaperless.DA.Entities.UserInfo, NPaperless.BL.Entities.UserInfo>();
            CreateMap<NPaperless.DA.Entities.DocTag, NPaperless.BL.Entities.DocTag>();

			CreateMap<NPaperless.BL.Entities.Document, NPaperless.DA.Entities.Document>();
			CreateMap<NPaperless.DA.Entities.Document, NPaperless.BL.Entities.Document>();
        }
    }
}