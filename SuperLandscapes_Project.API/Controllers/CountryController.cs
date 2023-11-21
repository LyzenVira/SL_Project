
using BLL.DTOs.CountryDTO;
using BLL.Services.Country;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        ///  All informations about countries 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetCountryDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var response = await _countryService.GetAllCountriesAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific country
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetCountryDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryByIdAsync(Guid id)
        {
            var response = await _countryService.GetCountryByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an country
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetCountryDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCountryAsync([FromBody] InsertCountryDTO countryDTO)
        {
            var response = await _countryService.InsertCountryAsync(countryDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an country by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetCountryDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCountryAsync([FromBody] UpdateCountryDTO countryDTO)
        {
            var response = await _countryService.UpdateCountryAsync(countryDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an country by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryById(Guid id)
        {
            var response = await _countryService.DeleteCountryByIdAsync(id);
            return Ok(response);
        }
    }
}