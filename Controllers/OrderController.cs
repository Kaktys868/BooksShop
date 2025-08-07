using BooksShop.DTO;
using BooksShop.Interfaces.Order;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/OrderController")]
    [ApiExplorerSettings(GroupName = "v11")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrder()
        {
            var Order = await _OrderService.GetAllOrderAsync();
            return Ok(Order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var Order = await _OrderService.GetOrderByIdAsync(id);
            if (Order == null) return NotFound();
            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody] CreateOrderDto OrderDto)
        {
            await _OrderService.AddOrderAsync(OrderDto);
            return CreatedAtAction(nameof(GetOrder), OrderDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] CreateOrderDto OrderDto)
        {
            await _OrderService.UpdateOrderAsync(id, OrderDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _OrderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
