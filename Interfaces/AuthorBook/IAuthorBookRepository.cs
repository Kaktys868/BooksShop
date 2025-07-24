namespace BooksShop.Interfaces.AuthorBook
{
    public interface IAuthorBookRepository
    {
        Task<Models.AuthorBook> GetByIdAsync(int id);
        Task<IEnumerable<Models.AuthorBook>> GetAllAsync();
        Task AddAsync(Models.AuthorBook authorBook);
        Task UpdateAsync(Models.AuthorBook authorBook);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
