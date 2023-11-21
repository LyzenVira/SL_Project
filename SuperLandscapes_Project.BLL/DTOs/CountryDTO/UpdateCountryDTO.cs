using SuperLandscapes_Project.BLL.DTOs.Base;

namespace SuperLandscapes_Project.BLL.DTOs.CountryDTO
{
    public class UpdateCountryDTO : UpdateBaseDTO
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
