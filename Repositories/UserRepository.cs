using BooksShop.Classes.Common;
using BooksShop.Interfaces.User;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnect _context;

        public UserRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User
                 .Select(u => new User
                 {
                     UserId = u.UserId,
                     UserFIO = u.UserFIO,
                     UserLogin = u.UserLogin,
                     UserPassword = u.UserPassword,
                     UserPhoneNumber = u.UserPhoneNumber,
                     RoleName = u.UserRoles.Select(ur => ur.Role.RoleName).FirstOrDefault()
                 })
                .FirstOrDefaultAsync(b => b.UserId == id);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User
                .Select(u => new User
                {
                    UserId = u.UserId,
                    UserFIO = u.UserFIO,
                    UserLogin = u.UserLogin,
                    UserPassword = u.UserPassword,
                    UserPhoneNumber = u.UserPhoneNumber,
                    RoleName = u.UserRoles.Select(ur => ur.Role.RoleName).FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task AddAsync(User User)
        {
            await _context.User.AddAsync(User);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User User)
        {
            _context.User.Update(User);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var User = await GetByIdAsync(id);
            if (User != null)
            {
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.User.AnyAsync(b => b.UserId == id);
        }
    }
}