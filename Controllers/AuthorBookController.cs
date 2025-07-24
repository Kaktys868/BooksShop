using BooksShop.DTO;
using BooksShop.Interfaces;
using BooksShop.Interfaces.AuthorBook;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/AuthorBookController")]
    [ApiExplorerSettings(GroupName = "v3")]
    public class AuthorBookController : ControllerBase
    {
        private readonly IAuthorBookService _AuthorBookService;

        public AuthorBookController(IAuthorBookService AuthorBookService)
        {
            _AuthorBookService = AuthorBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBookDto>>> GetAllAuthorBook()
        {
            var AuthorBook = await _AuthorBookService.GetAllAuthorBookAsync();
            return Ok(AuthorBook);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBookDto>> GetAuthorBook(int id)
        {
            var AuthorBook = await _AuthorBookService.GetAuthorBookByIdAsync(id);
            if (AuthorBook == null) return NotFound();
            return Ok(AuthorBook);
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthorBook([FromBody] CreateAuthorBookDto AuthorBookDto)
        {
            await _AuthorBookService.AddAuthorBookAsync(AuthorBookDto);
            return CreatedAtAction(nameof(GetAuthorBook), AuthorBookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthorBook(int id, [FromBody] CreateAuthorBookDto AuthorBookDto)
        {
            await _AuthorBookService.UpdateAuthorBookAsync(id, AuthorBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthorBook(int id)
        {
            await _AuthorBookService.DeleteAuthorBookAsync(id);
            return NoContent();
        }
    }
}