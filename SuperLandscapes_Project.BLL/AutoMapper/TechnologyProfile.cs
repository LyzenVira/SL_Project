using SuperLandscapes_Project.BLL.DTOs.TechnologyDTO;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class TechnologyProfile : BaseProfile
    {
        public TechnologyProfile()
        {
            CreateMap<Technology, GetTechnologyDTO>().ReverseMap();
            CreateMap<InsertTechnologyDTO, Technology>().ReverseMap();
            CreateMap<UpdateTechnologyDTO, Technology>().ReverseMap();
        }
    }
}
