using AutoMapper;
using SuperLandscapes_Project.BLL.DTOs.PictureDTO;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap< Picture, GetPictureDTO>().ReverseMap();
            CreateMap< Picture, InsertPictureDTO>().ReverseMap();
            CreateMap< Picture, UpdatePictureDTO>().ReverseMap();
        }
    }
}
