namespace BooksShop.Interfaces.Role
{
    public interface IRoleRepository
    {
        Task<Models.Role> GetByIdAsync(int id);
        Task<IEnumerable<Models.Role>> GetAllAsync();
        Task AddAsync(Models.Role role);
        Task UpdateAsync(Models.Role role);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
