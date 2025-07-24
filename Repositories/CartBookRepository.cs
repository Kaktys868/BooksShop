using BooksShop.Classes.Common;
using BooksShop.Interfaces.CartBook;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class CartBookRepository : ICartBookRepository
    {
        private readonly DbConnect _context;

        public CartBookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<CartBook> GetByIdAsync(int id)
        {
            return await _context.CartBook
                .Select(b => new CartBook
                {
                    CartBookId = b.CartBookId,
                    BookName = b.Book.BookName,
                    CartUserName = b.Cart.User.UserFIO
                })
                .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task<IEnumerable<CartBook>> GetAllAsync()
        {
            return await _context.CartBook
                .Select(b => new CartBook
                {
                    CartBookId = b.CartBookId,
                    BookName = b.Book.BookName,
                    CartUserName = b.Cart.User.UserFIO
                })
                .ToListAsync();
        }

        public async Task AddAsync(CartBook book)
        {
            await _context.CartBook.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartBook book)
        {
            _context.CartBook.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.CartBook.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.CartBook.AnyAsync(b => b.CartBookId == id);
        }
    }
}