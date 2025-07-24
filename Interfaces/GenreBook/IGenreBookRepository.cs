namespace BooksShop.Interfaces.GenreBook
{
    public interface IGenreBookRepository
    {
        Task<Models.GenreBook> GetByIdAsync(int id);
        Task<IEnumerable<Models.GenreBook>> GetAllAsync();
        Task AddAsync(Models.GenreBook genreBook);
        Task UpdateAsync(Models.GenreBook genreBook);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
