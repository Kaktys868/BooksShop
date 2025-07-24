using BooksShop.DTO;

namespace BooksShop.Interfaces.Genre
{
    public interface IGenreService
    {
        Task<GenreDto> GetGenreByIdAsync(int id);
        Task<IEnumerable<GenreDto>> GetAllGenreAsync();
        Task AddGenreAsync(CreateGenreDto genreDto);
        Task UpdateGenreAsync(int id, CreateGenreDto genreDto);
        Task DeleteGenreAsync(int id);
    }
}
