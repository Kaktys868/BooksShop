using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/GenreBookController")]
    [ApiExplorerSettings(GroupName = "v10")]
    public class GenreBookController : ControllerBase
    {
        private readonly IGenreBookService _genreBookService;

        public GenreBookController(IGenreBookService genreBookService)
        {
            _genreBookService = genreBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreBookDto>>> GetAllGenreBook()
        {
            var genreBook = await _genreBookService.GetAllGenreBookAsync();
            return Ok(genreBook);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreBookDto>> GetGenreBook(int id)
        {
            var genreBook = await _genreBookService.GetGenreBookByIdAsync(id);
            if (genreBook == null) return NotFound();
            return Ok(genreBook);
        }

        [HttpPost]
        public async Task<ActionResult> AddGenreBook([FromBody] CreateGenreBookDto genreBookDto)
        {
            await _genreBookService.AddGenreBookAsync(genreBookDto);
            return CreatedAtAction(nameof(GetGenreBook), genreBookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGenreBook(int id, [FromBody] CreateGenreBookDto genreBookDto)
        {
            await _genreBookService.UpdateGenreBookAsync(id, genreBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenreBook(int id)
        {
            await _genreBookService.DeleteGenreBookAsync(id);
            return NoContent();
        }
    }
}
