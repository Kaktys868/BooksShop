namespace BooksShop.Interfaces.CartBook
{
    public interface ICartBookRepository
    {
        Task<Models.CartBook> GetByIdAsync(int id);
        Task<IEnumerable<Models.CartBook>> GetAllAsync();
        Task AddAsync(Models.CartBook cartBook);
        Task UpdateAsync(Models.CartBook cartBook);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
