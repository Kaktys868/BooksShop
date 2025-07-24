namespace BooksShop.Interfaces.Admission
{
    public interface IAdmissionRepository
    {
        Task<Models.Admission> GetByIdAsync(int id);
        Task<IEnumerable<Models.Admission>> GetAllAsync();
        Task AddAsync(Models.Admission admission);
        Task UpdateAsync(Models.Admission admission);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
