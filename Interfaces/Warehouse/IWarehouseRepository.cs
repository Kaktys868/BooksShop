namespace BooksShop.Interfaces.Warehouse
{
    public interface IWarehouseRepository
    {
        Task<Models.Warehouse> GetByIdAsync(int id);
        Task<IEnumerable<Models.Warehouse>> GetAllAsync();
        Task AddAsync(Models.Warehouse warehouse);
        Task UpdateAsync(Models.Warehouse warehouse);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}