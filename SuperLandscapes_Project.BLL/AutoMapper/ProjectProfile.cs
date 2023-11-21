using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class ProjectProfile : BaseProfile
    {
        public ProjectProfile()
        {
            CreateMap< Project, GetProjectDTO>().ReverseMap();
            CreateMap<InsertProjectDTO,  Project>().ReverseMap();
            CreateMap<UpdateProjectDTO,  Project>().ReverseMap();
        }
    }
}
