using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IWarehouseBookService
    {
        Task<WarehouseBookDto> GetWarehouseBookByIdAsync(int id);
        Task<IEnumerable<WarehouseBookDto>> GetAllWarehouseBookAsync();
        Task AddWarehouseBookAsync(CreateWarehouseBookDto warehouseBookDto);
        Task UpdateWarehouseBookAsync(int id, CreateWarehouseBookDto warehouseBookDto);
        Task DeleteWarehouseBookAsync(int id);
    }
}