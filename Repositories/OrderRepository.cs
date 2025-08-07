using BooksShop.Classes.Common;
using BooksShop.Interfaces.Order;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public static DbConnect _context;

        public OrderRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Order
                .FirstOrDefaultAsync(b => b.OrderId == id);
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Order
                .ToListAsync();
        }

        public async Task AddAsync(Order Order)
        {
            await _context.Order.AddAsync(Order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order Order)
        {
            _context.Order.Update(Order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Order = await GetByIdAsync(id);
            if (Order != null)
            {
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Order.AnyAsync(b => b.OrderId == id);
        }
    }
}