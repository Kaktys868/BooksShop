using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DbConnect _context;

        public CartRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _context.Cart
                .Select(b => new Cart { 
                CartId = b.CartId,
                CartQuantity = b.CartQuantity,
                CartDateAdd = b.CartDateAdd,
                CartUserId = b.CartUserId,
                UserName = b.User.UserFIO
                })
                .FirstOrDefaultAsync(b => b.CartId == id);
        }
        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Cart
                .Select(b => new Cart
                {
                    CartId = b.CartId,
                    CartQuantity = b.CartQuantity,
                    CartDateAdd = b.CartDateAdd,
                    CartUserId = b.CartUserId,
                    UserName = b.User.UserFIO
                }).ToListAsync();
        }

        public async Task AddAsync(Cart Cart)
        {
            await _context.Cart.AddAsync(Cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart Cart)
        {
            _context.Cart.Update(Cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Cart = await GetByIdAsync(id);
            if (Cart != null)
            {
                _context.Cart.Remove(Cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cart.AnyAsync(b => b.CartId == id);
        }
    }
}