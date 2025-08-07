using BooksShop.Classes.Common;
using BooksShop.Interfaces.WarehouseBook;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class WarehouseBookRepository : IWarehouseBookRepository
    {
        private readonly DbConnect _context;

        public WarehouseBookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<WarehouseBook> GetByIdAsync(int id)
        {
            return await _context.WarehouseBook
                .Select(u => new WarehouseBook
                {
                    WarehouseBookId = u.WarehouseBookId,
                    WarehouseName = u.Warehouse.WarehouseName,
                    BookName = u.Book.BookName
                })
                .FirstOrDefaultAsync(b => b.WarehouseBookId == id);
        }

        public async Task<IEnumerable<WarehouseBook>> GetAllAsync()
        {
            return await _context.WarehouseBook
                .Select(u => new WarehouseBook
                {
                    WarehouseBookId = u.WarehouseBookId,
                    WarehouseName = u.Warehouse.WarehouseName,
                    BookName = u.Book.BookName
                })
                .ToListAsync();
        }

        public async Task AddAsync(WarehouseBook WarehouseBook)
        {
            await _context.WarehouseBook.AddAsync(WarehouseBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WarehouseBook WarehouseBook)
        {
            _context.WarehouseBook.Update(WarehouseBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var WarehouseBook = await GetByIdAsync(id);
            if (WarehouseBook != null)
            {
                _context.WarehouseBook.Remove(WarehouseBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WarehouseBook.AnyAsync(b => b.WarehouseBookId == id);
        }
    }
}