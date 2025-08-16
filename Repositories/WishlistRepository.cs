using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DbConnect _context;

        public WishlistRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Wishlist> GetByIdAsync(int id)
        {
            return await _context.Wishlist
                .FirstOrDefaultAsync(b => b.WishlistId == id);
        }

        public async Task<IEnumerable<Wishlist>> GetAllAsync()
        {
            return await _context.Wishlist
                .ToListAsync();
        }

        public async Task AddAsync(Wishlist Wishlist)
        {
            await _context.Wishlist.AddAsync(Wishlist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wishlist Wishlist)
        {
            _context.Wishlist.Update(Wishlist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Wishlist = await GetByIdAsync(id);
            if (Wishlist != null)
            {
                _context.Wishlist.Remove(Wishlist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Wishlist.AnyAsync(b => b.WishlistId == id);
        }
    }
}