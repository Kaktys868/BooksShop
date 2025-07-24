namespace BooksShop.Interfaces.WarehouseBook
{
    public interface IWarehouseBookRepository
    {
        Task<Models.WarehouseBook> GetByIdAsync(int id);
        Task<IEnumerable<Models.WarehouseBook>> GetAllAsync();
        Task AddAsync(Models.WarehouseBook warehouseBook);
        Task UpdateAsync(Models.WarehouseBook warehouseBook);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
