using BooksShop.DTO;
using BooksShop.Interfaces.Genre;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/GenreController")]
    [ApiExplorerSettings(GroupName = "v9")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllGenre()
        {
            var genre = await _genreService.GetAllGenreAsync();
            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null) return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre([FromBody] CreateGenreDto genreDto)
        {
            await _genreService.AddGenreAsync(genreDto);
            return CreatedAtAction(nameof(GetGenre), genreDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGenre(int id, [FromBody] CreateGenreDto genreDto)
        {
            await _genreService.UpdateGenreAsync(id, genreDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenreAsync(id);
            return NoContent();
        }
    }
}
