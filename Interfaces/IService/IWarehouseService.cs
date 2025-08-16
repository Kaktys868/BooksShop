using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IWarehouseService
    {
        Task<WarehouseDto> GetWarehouseByIdAsync(int id);
        Task<IEnumerable<WarehouseDto>> GetAllWarehouseAsync();
        Task AddWarehouseAsync(CreateWarehouseDto warehouseDto);
        Task UpdateWarehouseAsync(int id, CreateWarehouseDto warehouseDto);
        Task DeleteWarehouseAsync(int id);
    }
}