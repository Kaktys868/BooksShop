namespace BooksShop.Interfaces.Genre
{
    public interface IGenreRepository
    {
        Task<Models.Genre> GetByIdAsync(int id);
        Task<IEnumerable<Models.Genre>> GetAllAsync();
        Task AddAsync(Models.Genre genre);
        Task UpdateAsync(Models.Genre genre);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
