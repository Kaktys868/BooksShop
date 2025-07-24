namespace BooksShop.Interfaces.Author
{
    public interface IAuthorRepository
    {
        Task<Models.Author> GetByIdAsync(int id);
        Task<IEnumerable<Models.Author>> GetAllAsync();
        Task AddAsync(Models.Author author);
        Task UpdateAsync(Models.Author author);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}