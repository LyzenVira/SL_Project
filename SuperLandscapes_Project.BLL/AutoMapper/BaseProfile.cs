using AutoMapper;
using SuperLandscapes_Project.BLL.DTOs.Base;
using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<BaseEntity, GetBaseDto>().ReverseMap();
            CreateMap<BaseEntity, UpdateBaseDTO>().ReverseMap();

        }
    }
}
