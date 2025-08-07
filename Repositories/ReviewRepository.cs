using BooksShop.Classes.Common;
using BooksShop.Interfaces.Review;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DbConnect _context;

        public ReviewRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Review
                .FirstOrDefaultAsync(b => b.ReviewId == id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Review
                .ToListAsync();
        }

        public async Task AddAsync(Review Review)
        {
            await _context.Review.AddAsync(Review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review Review)
        {
            _context.Review.Update(Review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Review = await GetByIdAsync(id);
            if (Review != null)
            {
                _context.Review.Remove(Review);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Review.AnyAsync(b => b.ReviewId == id);
        }
    }
}