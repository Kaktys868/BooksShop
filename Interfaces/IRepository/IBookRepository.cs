namespace BooksShop.Interfaces.IRepository
{
    public interface IBookRepository
    {
        Task<Models.Book> GetByIdAsync(int id);
        Task<IEnumerable<Models.Book>> GetAllAsync();
        Task AddAsync(Models.Book book);
        Task UpdateAsync(Models.Book book);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
