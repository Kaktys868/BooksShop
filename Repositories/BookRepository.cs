using BooksShop.Classes.Common;
using BooksShop.Interfaces.Series;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksShop.Repositories
{
    public class BookRepository : Interfaces.Series.IBookRepository
    {
        private readonly DbConnect _context;

        public BookRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Book
                .Include(b => b.Series)
                .Include(b => b.Publishers)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.GenreBooks)
                    .ThenInclude(gb => gb.Genre)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book
                .Include(b => b.Series)
                .Include(b => b.Publishers)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.GenreBooks)
                    .ThenInclude(gb => gb.Genre)
                .ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Book.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Book.AnyAsync(b => b.BookId == id);
        }
    }
}