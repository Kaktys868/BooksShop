using BooksShop.Classes.Common;
using BooksShop.Interfaces.Author;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbConnect _context;

        public AuthorRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Author
                .Select(b => new Author
                {
                    AuthorId = b.AuthorId,
                    AuthorFIO = b.AuthorFIO,
                    AuthorDateOfBorn = b.AuthorDateOfBorn,
                    AuthorDateOfDeath = b.AuthorDateOfDeath
                })
                .FirstOrDefaultAsync(b => b.AuthorId == id);
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Author
                .Select(b => new Author
                {
                    AuthorId = b.AuthorId,
                    AuthorFIO = b.AuthorFIO,
                    AuthorDateOfBorn = b.AuthorDateOfBorn,
                    AuthorDateOfDeath = b.AuthorDateOfDeath
                })
                .ToListAsync();
        }

        public async Task AddAsync(Author Author)
        {
            await _context.Author.AddAsync(Author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author Author)
        {
            _context.Author.Update(Author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Author = await GetByIdAsync(id);
            if (Author != null)
            {
                _context.Author.Remove(Author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Author.AnyAsync(b => b.AuthorId == id);
        }
    }
}