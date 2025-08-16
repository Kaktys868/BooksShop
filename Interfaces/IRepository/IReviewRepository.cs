namespace BooksShop.Interfaces.IRepository
{
    public interface IReviewRepository
    {
        Task<Models.Review> GetByIdAsync(int id);
        Task<IEnumerable<Models.Review>> GetAllAsync();
        Task AddAsync(Models.Review review);
        Task UpdateAsync(Models.Review review);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
