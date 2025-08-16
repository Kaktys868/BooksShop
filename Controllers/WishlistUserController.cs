using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/WishlistUserController")]
    [ApiExplorerSettings(GroupName = "v22")]
    public class WishlistUserController : ControllerBase
    {
        private readonly IWishlistUserService _WishlistUserService;

        public WishlistUserController(IWishlistUserService WishlistUserService)
        {
            _WishlistUserService = WishlistUserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistUserDto>>> GetAllWishlistUser()
        {
            var WishlistUsers = await _WishlistUserService.GetAllWishlistUserAsync();
            return Ok(WishlistUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishlistUserDto>> GetWishlistUser(int id)
        {
            var WishlistUser = await _WishlistUserService.GetWishlistUserByIdAsync(id);
            if (WishlistUser == null) return NotFound();
            return Ok(WishlistUser);
        }

        [HttpPost]
        public async Task<ActionResult> AddWishlistUser([FromBody] CreateWishlistUserDto WishlistUserDto)
        {
            await _WishlistUserService.AddWishlistUserAsync(WishlistUserDto);
            return CreatedAtAction(nameof(GetWishlistUser), WishlistUserDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWishlistUser(int id, [FromBody] CreateWishlistUserDto WishlistUserDto)
        {
            await _WishlistUserService.UpdateWishlistUserAsync(id, WishlistUserDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWishlistUser(int id)
        {
            await _WishlistUserService.DeleteWishlistUserAsync(id);
            return NoContent();
        }
    }
}