using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllOrderAsync();
        Task AddOrderAsync(CreateOrderDto orderDto);
        Task UpdateOrderAsync(int id, CreateOrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}