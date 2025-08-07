using BooksShop.Classes.Common;
using BooksShop.Interfaces.Admission;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksShop.Repositories
{
    public class AdmissionRepositroy : IAdmissionRepository
    {
        private readonly DbConnect _context;

        public AdmissionRepositroy(DbConnect context)
        {
            _context = context;
        }

        public async Task<Admission> GetByIdAsync(int id)
        {
            return await _context.Admission
                .FirstOrDefaultAsync(b => b.AdmissionId == id);
        }
        public async Task<IEnumerable<Admission>> GetAllAsync()
        {
            return await _context.Admission
                .ToListAsync();
        }

        public async Task AddAsync(Admission Admission)
        {
            await _context.Admission.AddAsync(Admission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Admission Admission)
        {
            _context.Admission.Update(Admission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Admission = await GetByIdAsync(id);
            if (Admission != null)
            {
                _context.Admission.Remove(Admission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Admission.AnyAsync(b => b.AdmissionId == id);
        }
    }
}