namespace BooksShop.Interfaces.City
{
    public interface ICityRepository
    {
        Task<Models.City> GetByIdAsync(int id);
        Task<IEnumerable<Models.City>> GetAllAsync();
        Task AddAsync(Models.City city);
        Task UpdateAsync(Models.City city);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
