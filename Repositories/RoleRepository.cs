using BooksShop.Classes.Common;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbConnect _context;

        public RoleRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Role
                .FirstOrDefaultAsync(b => b.RoleId == id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Role
                .ToListAsync();
        }

        public async Task AddAsync(Role Role)
        {
            await _context.Role.AddAsync(Role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role Role)
        {
            _context.Role.Update(Role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Role = await GetByIdAsync(id);
            if (Role != null)
            {
                _context.Role.Remove(Role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Role.AnyAsync(b => b.RoleId == id);
        }
    }
}