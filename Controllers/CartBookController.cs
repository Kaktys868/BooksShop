using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/CartBookController")]
    [ApiExplorerSettings(GroupName = "v6")]
    public class CartBookController : ControllerBase
    {
        private readonly ICartBookService _CartBookService;

        public CartBookController(ICartBookService CartBookService)
        {
            _CartBookService = CartBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartBookDto>>> GetAllCartBook()
        {
            var CartBooks = await _CartBookService.GetAllCartBookAsync();
            return Ok(CartBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartBookDto>> GetCartBook(int id)
        {
            var CartBook = await _CartBookService.GetCartBookByIdAsync(id);
            if (CartBook == null) return NotFound();
            return Ok(CartBook);
        }

        [HttpPost]
        public async Task<ActionResult> AddCartBook([FromBody] CreateCartBookDto CartBookDto)
        {
            await _CartBookService.AddCartBookAsync(CartBookDto);
            return CreatedAtAction(nameof(GetCartBook), CartBookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCartBook(int id, [FromBody] CreateCartBookDto CartBookDto)
        {
            await _CartBookService.UpdateCartBookAsync(id, CartBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCartBook(int id)
        {
            await _CartBookService.DeleteCartBookAsync(id);
            return NoContent();
        }
    }
}
