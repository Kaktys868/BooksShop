using BooksShop.DTO;

namespace BooksShop.Interfaces.WarehouseBook
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