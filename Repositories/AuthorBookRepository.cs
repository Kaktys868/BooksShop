using BooksShop.Classes.Common;
using BooksShop.Interfaces.AuthorBook;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly DbConnect _context;

        public AuthorBookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<AuthorBook> GetByIdAsync(int id)
        {
            return await _context.AuthorBook
                .Select(b => new AuthorBook
                {
                    AuthorBookId = b.AuthorBookId,
                    AuthorId = b.AuthorId,
                    BookId = b.BookId,
                    BookName = b.Book.BookName,
                    AuthorName = b.Author.AuthorFIO
                })
                .FirstOrDefaultAsync(b => b.AuthorBookId == id);
        }
        public async Task<IEnumerable<AuthorBook>> GetAllAsync()
        {
            return await _context.AuthorBook
                .Select(b => new AuthorBook
                {
                    AuthorBookId = b.AuthorBookId,
                    AuthorId = b.AuthorId,
                    BookId = b.BookId,
                    BookName = b.Book.BookName,
                    AuthorName = b.Author.AuthorFIO
                })
                .ToListAsync();
        }

        public async Task AddAsync(AuthorBook AuthorBook)
        {
            await _context.AuthorBook.AddAsync(AuthorBook);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuthorBook AuthorBook)
        {
            _context.AuthorBook.Update(AuthorBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var AuthorBook = await GetByIdAsync(id);
            if (AuthorBook != null)
            {
                _context.AuthorBook.Remove(AuthorBook);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.AuthorBook.AnyAsync(b => b.AuthorBookId == id);
        }
    }
}