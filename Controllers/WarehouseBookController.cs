using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/WarehouseBookController")]
    [ApiExplorerSettings(GroupName = "v19")]
    public class WarehouseBookController : ControllerBase
    {
        private readonly IWarehouseBookService _WarehouseBookService;

        public WarehouseBookController(IWarehouseBookService WarehouseBookService)
        {
            _WarehouseBookService = WarehouseBookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseBookDto>>> GetAllWarehouseBook()
        {
            var WarehouseBooks = await _WarehouseBookService.GetAllWarehouseBookAsync();
            return Ok(WarehouseBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseBookDto>> GetWarehouseBook(int id)
        {
            var WarehouseBook = await _WarehouseBookService.GetWarehouseBookByIdAsync(id);
            if (WarehouseBook == null) return NotFound();
            return Ok(WarehouseBook);
        }

        [HttpPost]
        public async Task<ActionResult> AddWarehouseBook([FromBody] CreateWarehouseBookDto WarehouseBookDto)
        {
            await _WarehouseBookService.AddWarehouseBookAsync(WarehouseBookDto);
            return CreatedAtAction(nameof(GetWarehouseBook), WarehouseBookDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWarehouseBook(int id, [FromBody] CreateWarehouseBookDto WarehouseBookDto)
        {
            await _WarehouseBookService.UpdateWarehouseBookAsync(id, WarehouseBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWarehouseBook(int id)
        {
            await _WarehouseBookService.DeleteWarehouseBookAsync(id);
            return NoContent();
        }
    }
}