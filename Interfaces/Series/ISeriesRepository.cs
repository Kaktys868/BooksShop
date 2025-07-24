namespace BooksShop.Interfaces.Series
{
    public interface ISeriesRepository
    {
        Task<Models.Series> GetByIdAsync(int id);
        Task<IEnumerable<Models.Series>> GetAllAsync();
        Task AddAsync(Models.Series series);
        Task UpdateAsync(Models.Series series);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
