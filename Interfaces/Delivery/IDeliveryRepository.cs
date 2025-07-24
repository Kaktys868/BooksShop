namespace BooksShop.Interfaces.Delivery
{
    public interface IDeliveryRepository
    {
        Task<Models.Delivery> GetByIdAsync(int id);
        Task<IEnumerable<Models.Delivery>> GetAllAsync();
        Task AddAsync(Models.Delivery delivery);
        Task UpdateAsync(Models.Delivery delivery);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}