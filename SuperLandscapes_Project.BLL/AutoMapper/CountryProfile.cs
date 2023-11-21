using SuperLandscapes_Project.BLL.DTOs.CountryDTO;
using SuperLandscapes_Project.DAL.Entities;

namespace SuperLandscapes_Project.BLL.AutoMapper
{
    public class CountryProfile : BaseProfile
    {
        public CountryProfile()
        {
            CreateMap< Country, GetCountryDTO>().ReverseMap();

            CreateMap<InsertCountryDTO,  Country>().ReverseMap();

            CreateMap<UpdateCountryDTO,  Country>().ReverseMap();
        }
    }
}
