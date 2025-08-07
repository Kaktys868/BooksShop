using BooksShop.DTO;
using BooksShop.Interfaces.Warehouse;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/WarehouseController")]
    [ApiExplorerSettings(GroupName = "v18")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _WarehouseService;

        public WarehouseController(IWarehouseService WarehouseService)
        {
            _WarehouseService = WarehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAllWarehouse()
        {
            var Warehouses = await _WarehouseService.GetAllWarehouseAsync();
            return Ok(Warehouses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetWarehouse(int id)
        {
            var Warehouse = await _WarehouseService.GetWarehouseByIdAsync(id);
            if (Warehouse == null) return NotFound();
            return Ok(Warehouse);
        }

        [HttpPost]
        public async Task<ActionResult> AddWarehouse([FromBody] CreateWarehouseDto WarehouseDto)
        {
            await _WarehouseService.AddWarehouseAsync(WarehouseDto);
            return CreatedAtAction(nameof(GetWarehouse), WarehouseDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWarehouse(int id, [FromBody] CreateWarehouseDto WarehouseDto)
        {
            await _WarehouseService.UpdateWarehouseAsync(id, WarehouseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWarehouse(int id)
        {
            await _WarehouseService.DeleteWarehouseAsync(id);
            return NoContent();
        }
    }
}