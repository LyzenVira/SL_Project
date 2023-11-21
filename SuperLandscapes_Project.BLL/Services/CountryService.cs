using AutoMapper;
using AutoMapper.QueryableExtensions;
using SuperLandscapes_Project.BLL.DTOs.CountryDTO;
using SuperLandscapes_Project.BLL.DTOs.ProjectDTO;
using SuperLandscapes_Project.BLL.DTOs.TechnologyDTO;
using SuperLandscapes_Project.DAL.Entities;
using SuperLandscapes_Project.DAL.UnitOfWork.Interface;

namespace BLL.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, IUnitOfWork repository)
        {
            _mapper = mapper;
            _unitOfWork = repository;
        }
        public async Task<string> DeleteCountryByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.CountryRepository.GetByIdAsync(id) ?? throw new Exception("Not found exception");
            await _unitOfWork.CountryRepository.DeleteAsync(entity.Id);
             _unitOfWork.Save();

            return "Successful";
        }

        public async Task<IEnumerable<GetCountryDTO>> GetAllCountriesAsync()
        {
            var countries = await _unitOfWork.CountryRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetCountryDTO>>(countries);
            return result;
        }

        public async Task<GetCountryDTO> GetCountryByIdAsync(Guid id)
        {
            var country = await _unitOfWork.CountryRepository.GetByIdAsync(id);
            return _mapper.Map<GetCountryDTO>(country);

        }

        public async Task<GetCountryDTO> InsertCountryAsync(InsertCountryDTO insertCountryDTO)
        {
            var country = await _unitOfWork.CountryRepository.CreateAsync(_mapper.Map<SuperLandscapes_Project.DAL.Entities.Country>(insertCountryDTO));
             _unitOfWork.Save();

            return _mapper.Map<GetCountryDTO>(country);
        }

        public async Task<GetCountryDTO> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO)
        {
            var country = await _unitOfWork.CountryRepository.UpdateAsync(_mapper.Map<SuperLandscapes_Project.DAL.Entities.Country>(updateCountryDTO));
             _unitOfWork.Save();

            return _mapper.Map<GetCountryDTO>(country);
        }
    }
}