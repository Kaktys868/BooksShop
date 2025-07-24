using BooksShop.Classes.Common;
using BooksShop.Interfaces.GenreBook;
using BooksShop.Interfaces.Series;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class GenreBookRepository : IGenreBookRepository
    {
        private readonly DbConnect _context;

        public GenreBookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<GenreBook> GetByIdAsync(int id)
        {
            return await _context.GenreBook
                .Select(b => new GenreBook
                {
                    GenreBookId = b.GenreBookId,
                    BookName = b.Book.BookName,
                    GenreName = b.Genre.GenreName
                })
                .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task<IEnumerable<GenreBook>> GetAllAsync()
        {
            return await _context.GenreBook
                .Select(b => new GenreBook
                {
                    GenreBookId = b.GenreBookId,
                    BookName = b.Book.BookName,
                    GenreName = b.Genre.GenreName
                })
                .ToListAsync();
        }

        public async Task AddAsync(GenreBook book)
        {
            await _context.GenreBook.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GenreBook book)
        {
            _context.GenreBook.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.GenreBook.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.GenreBook.AnyAsync(b => b.GenreBookId == id);
        }
    }
}