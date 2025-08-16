namespace BooksShop.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<Models.User> GetByIdAsync(int id);
        Task<IEnumerable<Models.User>> GetAllAsync();
        Task AddAsync(Models.User user);
        Task UpdateAsync(Models.User user);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}