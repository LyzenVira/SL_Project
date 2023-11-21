using AutoMapper;
using SuperLandscapes_Project.BLL.DTOs.ParagraphDTO;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class ParagraphProfile : Profile
    {
        public ParagraphProfile()
        {
            CreateMap< Paragraph, GetParagraphDTO>().ReverseMap();
            CreateMap< Paragraph, InsertParagraphDTO>().ReverseMap();
            CreateMap< Paragraph, UpdateParagraphDTO>().ReverseMap();
        }
    }
}
