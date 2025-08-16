using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class WishlistUserRepository : IWishlistUserRepository
    {
        private readonly DbConnect _context;

        public WishlistUserRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<WishlistUser> GetByIdAsync(int id)
        {
            return await _context.WishlistUser
                .Select(wb => new WishlistUser
                {
                    WishlistUserId = wb.WishlistUserId,
                    WishlistName = wb.Wishlist.WishlistName,
                    UserName = wb.User.UserFIO
                })
                .FirstOrDefaultAsync(b => b.WishlistUserId == id);
        }

        public async Task<IEnumerable<WishlistUser>> GetAllAsync()
        {
            return await _context.WishlistUser
                .Select(wb => new WishlistUser
                {
                    WishlistUserId = wb.WishlistUserId,
                    WishlistName = wb.Wishlist.WishlistName,
                    UserName = wb.User.UserFIO
                })
                .ToListAsync();
        }

        public async Task AddAsync(WishlistUser WishlistUser)
        {
            await _context.WishlistUser.AddAsync(WishlistUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WishlistUser WishlistUser)
        {
            _context.WishlistUser.Update(WishlistUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var WishlistUser = await GetByIdAsync(id);
            if (WishlistUser != null)
            {
                _context.WishlistUser.Remove(WishlistUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WishlistUser.AnyAsync(b => b.WishlistUserId == id);
        }
    }
}