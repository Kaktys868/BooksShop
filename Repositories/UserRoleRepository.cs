using BooksShop.Classes.Common;
using BooksShop.Interfaces.UserRole;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbConnect _context;

        public UserRoleRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _context.UsersRole
                .FirstOrDefaultAsync(b => b.UserRoleId == id);
        }
        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UsersRole
                .ToListAsync();
        }

        public async Task AddAsync(UserRole UserRole)
        {
            await _context.UsersRole.AddAsync(UserRole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserRole UserRole)
        {
            _context.UsersRole.Update(UserRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var UserRole = await GetByIdAsync(id);
            if (UserRole != null)
            {
                _context.UsersRole.Remove(UserRole);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.UsersRole.AnyAsync(b => b.UserRoleId == id);
        }
    }
}