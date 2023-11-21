
using SuperLandscapes_Project.BLL.DTOs.CountryDTO;
using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;

namespace BLL.Services.Country
{
    public interface ICountryService
    {
        Task<IEnumerable<GetCountryDTO>> GetAllCountriesAsync();
        Task<GetCountryDTO> GetCountryByIdAsync(Guid id);
        Task<GetCountryDTO> InsertCountryAsync(InsertCountryDTO insertCountryDTO);
        Task<GetCountryDTO> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO);
        Task<string> DeleteCountryByIdAsync(Guid id);
    }
}
