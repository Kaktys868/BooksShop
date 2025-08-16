namespace BooksShop.Interfaces.IRepository
{
    public interface IUserRoleRepository
    {
        Task<Models.UserRole> GetByIdAsync(int id);
        Task<IEnumerable<Models.UserRole>> GetAllAsync();
        Task AddAsync(Models.UserRole userRole);
        Task UpdateAsync(Models.UserRole userRole);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}