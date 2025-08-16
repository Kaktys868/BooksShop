using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/CartController")]
    [ApiExplorerSettings(GroupName = "v5")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _CartService;

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetAllCart()
        {
            var Carts = await _CartService.GetAllCartAsync();
            return Ok(Carts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetCart(int id)
        {
            var Cart = await _CartService.GetCartByIdAsync(id);
            if (Cart == null) return NotFound();
            return Ok(Cart);
        }

        [HttpPost]
        public async Task<ActionResult> AddCart([FromBody] CreateCartDto CartDto)
        {
            await _CartService.AddCartAsync(CartDto);
            return CreatedAtAction(nameof(GetCart), CartDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCart(int id, [FromBody] CreateCartDto CartDto)
        {
            await _CartService.UpdateCartAsync(id, CartDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart(int id)
        {
            await _CartService.DeleteCartAsync(id);
            return NoContent();
        }
    }
}