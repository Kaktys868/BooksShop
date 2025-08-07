using BooksShop.Classes.Common;
using BooksShop.Interfaces.WishlistBook;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class WishlistBookRepository : IWishlistBookRepository
    {
        private readonly DbConnect _context;

        public WishlistBookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<WishlistBook> GetByIdAsync(int id)
        {
            return await _context.WishlistBook
                .Select(wb => new WishlistBook
                {
                    WishlistBookId = wb.WishlistBookId,
                    WishlistName = wb.Wishlist.WishlistName,
                    BookName = wb.Book.BookName
                })
                .FirstOrDefaultAsync(b => b.WishlistBookId == id);
        }

        public async Task<IEnumerable<WishlistBook>> GetAllAsync()
        {
            return await _context.WishlistBook
                .Select(wb => new WishlistBook
                {
                    WishlistBookId = wb.WishlistBookId,
                    WishlistName = wb.Wishlist.WishlistName,
                    BookName = wb.Book.BookName
                })
                .ToListAsync();
        }

        public async Task AddAsync(WishlistBook WishlistBook)
        {
            await _context.WishlistBook.AddAsync(WishlistBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WishlistBook WishlistBook)
        {
            _context.WishlistBook.Update(WishlistBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var WishlistBook = await GetByIdAsync(id);
            if (WishlistBook != null)
            {
                _context.WishlistBook.Remove(WishlistBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WishlistBook.AnyAsync(b => b.WishlistBookId == id);
        }
    }
}