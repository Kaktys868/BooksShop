using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/WishlistBookController")]
    [ApiExplorerSettings(GroupName = "v21")]
    public class WishlistBookController : ControllerBase
    {
        private readonly IWishlistBookService _WishlistBookService;

        public WishlistBookController(IWishlistBookService WishlistBookService)
        {
            _WishlistBookService = WishlistBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishlistBookDto>>> GetAllWishlistBook()
        {
            var WishlistBooks = await _WishlistBookService.GetAllWishlistBookAsync();
            return Ok(WishlistBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WishlistBookDto>> GetWishlistBook(int id)
        {
            var WishlistBook = await _WishlistBookService.GetWishlistBookByIdAsync(id);
            if (WishlistBook == null) return NotFound();
            return Ok(WishlistBook);
        }

        [HttpPost]
        public async Task<ActionResult> AddWishlistBook([FromBody] CreateWishlistBookDto WishlistBookDto)
        {
            await _WishlistBookService.AddWishlistBookAsync(WishlistBookDto);
            return CreatedAtAction(nameof(GetWishlistBook), WishlistBookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWishlistBook(int id, [FromBody] CreateWishlistBookDto WishlistBookDto)
        {
            await _WishlistBookService.UpdateWishlistBookAsync(id, WishlistBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWishlistBook(int id)
        {
            await _WishlistBookService.DeleteWishlistBookAsync(id);
            return NoContent();
        }
    }
}