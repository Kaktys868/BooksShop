using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IGenreBookService
    {
        Task<GenreBookDto> GetGenreBookByIdAsync(int id);
        Task<IEnumerable<GenreBookDto>> GetAllGenreBookAsync();
        Task AddGenreBookAsync(CreateGenreBookDto genreBookDto);
        Task UpdateGenreBookAsync(int id, CreateGenreBookDto genreBookDto);
        Task DeleteGenreBookAsync(int id);
    }
}
