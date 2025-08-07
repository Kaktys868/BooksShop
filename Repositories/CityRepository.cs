using BooksShop.Classes.Common;
using BooksShop.Interfaces.City;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BooksShop.Repositories
{
    public class CityRepository : ICityRepository
    {
        public static DbConnect _context;

        public CityRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.City
                .Select(b => new City
                {
                    CityId = b.CityId,
                    CityName = b.CityName
                })
                .FirstOrDefaultAsync(b => b.CityId == id);
        }
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.City
                .Select(c => new City
                {
                    CityId = c.CityId,
                    CityName = c.CityName
                })
                .ToListAsync(); 
        }

        public async Task AddAsync(City City)
        {
            await _context.City.AddAsync(City);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(City City)
        {
            _context.City.Update(City);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var City = await GetByIdAsync(id);
            if (City != null)
            {
                _context.City.Remove(City);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.City.AnyAsync(b => b.CityId == id);
        }
    }
}