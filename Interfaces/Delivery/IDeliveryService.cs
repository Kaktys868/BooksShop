using BooksShop.DTO;

namespace BooksShop.Interfaces.Delivery
{
    public interface IDeliveryService
    {
        Task<DeliveryDto> GetDeliveryByIdAsync(int id);
        Task<IEnumerable<DeliveryDto>> GetAllDeliveryAsync();
        Task AddDeliveryAsync(CreateDeliveryDto deliveryDto);
        Task UpdateDeliveryAsync(int id, CreateDeliveryDto deliveryDto);
        Task DeleteDeliveryAsync(int id);
    }
}