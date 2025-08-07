using BooksShop.Classes.Common;
using BooksShop.Interfaces.Book;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BooksShop.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbConnect _context;

        public BookRepository(DbConnect context)
        {
            _context = context;
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Book
                .Select(b => new Book
                {
                    BookId = b.BookId,
                    BookName = b.BookName,
                    BookDateDesign = b.BookDateDesign,
                    BookCost = b.BookCost,
                    SeriesName = b.Series.SeriesName,
                    PublisherName = b.Publishers.PublisherName,
                    GenreName = b.GenreBooks
                    .Select(gb => gb.Genre.GenreName)
                    .FirstOrDefault()
                })
                .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book
                .Select(b => new Book
                {
                    BookId = b.BookId,
                    BookName = b.BookName,
                    BookDateDesign = b.BookDateDesign,
                    BookCost = b.BookCost,
                    SeriesName = b.Series.SeriesName,
                    PublisherName = b.Publishers.PublisherName,
                    GenreName = b.GenreBooks
                    .Select(gb => gb.Genre.GenreName)
                    .FirstOrDefault(),
                    AuthorNames = b.AuthorBooks
                    .Select(ab => ab.Author.AuthorFIO)
                    .FirstOrDefault()
                })
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