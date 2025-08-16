using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        public static DbConnect _context;

        public DeliveryRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Delivery> GetByIdAsync(int id)
        {
            return await _context.Delivery
                .Select(p => new Delivery
                {
                    DeliveryId = p.DeliveryId,
                    DeliveryQuantity = p.DeliveryQuantity,
                    DeliveryDate = p.DeliveryDate,
                    BookName = p.Book.BookName,
                    WarehouseName = p.Warehouse.WarehouseName
                })
                .FirstOrDefaultAsync(b => b.DeliveryId == id);
        }
        public async Task<IEnumerable<Delivery>> GetAllAsync()
        {
            return await _context.Delivery
                .Select(p => new Delivery
                {
                    DeliveryId = p.DeliveryId,
                    DeliveryQuantity = p.DeliveryQuantity,
                    DeliveryDate = p.DeliveryDate,
                    BookName = p.Book.BookName,
                    WarehouseName = p.Warehouse.WarehouseName
                })
                .ToListAsync();
        }

        public async Task AddAsync(Delivery Delivery)
        {
            await _context.Delivery.AddAsync(Delivery);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Delivery Delivery)
        {
            _context.Delivery.Update(Delivery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Delivery = await GetByIdAsync(id);
            if (Delivery != null)
            {
                _context.Delivery.Remove(Delivery);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Delivery.AnyAsync(b => b.DeliveryId == id);
        }
    }
}