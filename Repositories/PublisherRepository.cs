using BooksShop.Classes.Common;
using BooksShop.Interfaces;
using BooksShop.Interfaces.Publisher;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksShop.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DbConnect _context;

        public PublisherRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _context.Publisher
                .FirstOrDefaultAsync(b => b.PublisherId == id);
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publisher
                .ToListAsync();
        }

        public async Task AddAsync(Publisher publisher)
        {
            await _context.Publisher.AddAsync(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            _context.Publisher.Update(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await GetByIdAsync(id);
            if (publisher != null)
            {
                _context.Publisher.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Publisher.AnyAsync(b => b.PublisherId == id);
        }
    }
}