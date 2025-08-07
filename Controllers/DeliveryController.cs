using BooksShop.DTO;
using BooksShop.Interfaces.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/DeliveryController")]
    [ApiExplorerSettings(GroupName = "v8")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _DeliveryService;

        public DeliveryController(IDeliveryService DeliveryService)
        {
            _DeliveryService = DeliveryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetAllDelivery()
        {
            var Deliverys = await _DeliveryService.GetAllDeliveryAsync();
            return Ok(Deliverys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetDelivery(int id)
        {
            var Delivery = await _DeliveryService.GetDeliveryByIdAsync(id);
            if (Delivery == null) return NotFound();
            return Ok(Delivery);
        }

        [HttpPost]
        public async Task<ActionResult> AddDelivery([FromBody] CreateDeliveryDto DeliveryDto)
        {
            await _DeliveryService.AddDeliveryAsync(DeliveryDto);
            return CreatedAtAction(nameof(GetDelivery), DeliveryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDelivery(int id, [FromBody] CreateDeliveryDto DeliveryDto)
        {
            await _DeliveryService.UpdateDeliveryAsync(id, DeliveryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDelivery(int id)
        {
            await _DeliveryService.DeleteDeliveryAsync(id);
            return NoContent();
        }
    }
}