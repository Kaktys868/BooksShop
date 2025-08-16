namespace BooksShop.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<Models.Order> GetByIdAsync(int id);
        Task<IEnumerable<Models.Order>> GetAllAsync();
        Task AddAsync(Models.Order order);
        Task UpdateAsync(Models.Order order);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
