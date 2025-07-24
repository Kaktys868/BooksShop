using BooksShop.DTO;
using BooksShop.Interfaces;
using BooksShop.Interfaces.Series;
using BooksShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BooksShop.Controllers
{
    [Route("api/SeriesController")]
    [ApiExplorerSettings(GroupName = "v15")]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesDto>>> GetAllSeries()
        {
            var series = await _seriesService.GetAllSeriesAsync();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDto>> GetSeries(int id)
        {
            var series = await _seriesService.GetSeriesByIdAsync(id);
            if (series == null) return NotFound();
            return Ok(series);
        }

        [HttpPost]
        public async Task<ActionResult> AddSeries([FromBody] CreateSeriesDto seriesDto)
        {
            await _seriesService.AddSeriesAsync(seriesDto);
            return CreatedAtAction(nameof(GetSeries), seriesDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeries(int id, [FromBody] CreateSeriesDto seriesDto)
        {
            await _seriesService.UpdateSeriesAsync(id, seriesDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeries(int id)
        {
            await _seriesService.DeleteSeriesAsync(id);
            return NoContent();
        }
    }
}
