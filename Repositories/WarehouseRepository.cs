using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DbConnect _context;

        public WarehouseRepository(DbConnect context)
        {
            _context = context;
        }
        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _context.Warehouse
                .Select(b => new Warehouse
                {
                    WarehouseId = b.WarehouseId,
                    WarehouseName = b.WarehouseName,
                    WarehouseBooksQuantity = b.WarehouseBooksQuantity,
                    WarehouseCityId = b.City.CityId,
                    CityName = b.City.CityName
                })
                .FirstOrDefaultAsync(b => b.WarehouseId == id);
        }
        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouse
                .Select(b => new Warehouse
                {
                    WarehouseId = b.WarehouseId,
                    WarehouseName = b.WarehouseName,
                    WarehouseBooksQuantity = b.WarehouseBooksQuantity,
                    WarehouseCityId = b.City.CityId,
                    CityName = b.City.CityName
                })
                .ToListAsync();
        }

        public async Task AddAsync(Warehouse Warehouse)
        {
            await _context.Warehouse.AddAsync(Warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse Warehouse)
        {
            _context.Warehouse.Update(Warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Warehouse = await GetByIdAsync(id);
            if (Warehouse != null)
            {
                _context.Warehouse.Remove(Warehouse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Warehouse.AnyAsync(b => b.WarehouseId == id);
        }
    }
}