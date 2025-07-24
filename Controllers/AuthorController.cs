using BooksShop.DTO;
using BooksShop.Interfaces.Author;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/AuthorController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService AuthorService)
        {
            _AuthorService = AuthorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthor()
        {
            var Author = await _AuthorService.GetAllAuthorAsync();
            return Ok(Author);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var Author = await _AuthorService.GetAuthorByIdAsync(id);
            if (Author == null) return NotFound();
            return Ok(Author);
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] CreateAuthorDto AuthorDto)
        {
            await _AuthorService.AddAuthorAsync(AuthorDto);
            return CreatedAtAction(nameof(GetAuthor), AuthorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] CreateAuthorDto AuthorDto)
        {
            await _AuthorService.UpdateAuthorAsync(id, AuthorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _AuthorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}