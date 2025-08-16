using BooksShop.Classes.Common;
using BooksShop.Interfaces;
using BooksShop.Interfaces.IRepository;
using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksShop.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly DbConnect _context;

        public SeriesRepository(DbConnect context)
        {
            _context = context;
        }

        public async Task<Series> GetByIdAsync(int id)
        {
            return await _context.Series
                .FirstOrDefaultAsync(b => b.SeriesId == id);
        }

        public async Task<IEnumerable<Series>> GetAllAsync()
        {
            return await _context.Series
                .ToListAsync();
        }

        public async Task AddAsync(Series series)
        {
            await _context.Series.AddAsync(series);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Series series)
        {
            _context.Series.Update(series);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var series = await GetByIdAsync(id);
            if (series != null)
            {
                _context.Series.Remove(series);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Series.AnyAsync(b => b.SeriesId == id);
        }
    }
}