using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/CityController")]
    [ApiExplorerSettings(GroupName = "v7")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _CityService;

        public CityController(ICityService CityService)
        {
            _CityService = CityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCity()
        {
            var Citys = await _CityService.GetAllCityAsync();
            return Ok(Citys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            var City = await _CityService.GetCityByIdAsync(id);
            if (City == null) return NotFound();
            return Ok(City);
        }

        [HttpPost]
        public async Task<ActionResult> AddCity([FromBody] CreateCityDto CityDto)
        {
            await _CityService.AddCityAsync(CityDto);
            return CreatedAtAction(nameof(GetCity), CityDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCity(int id, [FromBody] CreateCityDto CityDto)
        {
            await _CityService.UpdateCityAsync(id, CityDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            await _CityService.DeleteCityAsync(id);
            return NoContent();
        }
    }
}