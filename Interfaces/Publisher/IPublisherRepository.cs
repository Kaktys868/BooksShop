namespace BooksShop.Interfaces.Publisher
{
    public interface IPublisherRepository
    {
        Task<Models.Publisher> GetByIdAsync(int id);
        Task<IEnumerable<Models.Publisher>> GetAllAsync();
        Task AddAsync(Models.Publisher publisher);
        Task UpdateAsync(Models.Publisher Publisher);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
