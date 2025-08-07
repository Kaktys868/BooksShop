using BooksShop.DTO;
using BooksShop.Interfaces.Wishlist;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/WishlistController")]
    [ApiExplorerSettings(GroupName = "v20")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _WishlistService;

        public WishlistController(IWishlistService WishlistService)
        {
            _WishlistService = WishlistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistDto>>> GetAllWishlist()
        {
            var Wishlists = await _WishlistService.GetAllWishlistAsync();
            return Ok(Wishlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishlistDto>> GetWishlist(int id)
        {
            var Wishlist = await _WishlistService.GetWishlistByIdAsync(id);
            if (Wishlist == null) return NotFound();
            return Ok(Wishlist);
        }

        [HttpPost]
        public async Task<ActionResult> AddWishlist([FromBody] CreateWishlistDto WishlistDto)
        {
            await _WishlistService.AddWishlistAsync(WishlistDto);
            return CreatedAtAction(nameof(GetWishlist), WishlistDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWishlist(int id, [FromBody] CreateWishlistDto WishlistDto)
        {
            await _WishlistService.UpdateWishlistAsync(id, WishlistDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWishlist(int id)
        {
            await _WishlistService.DeleteWishlistAsync(id);
            return NoContent();
        }
    }
}