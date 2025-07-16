using BooksShop.DTO;

namespace BooksShop.Interfaces.Series
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task AddBookAsync(CreateBookDto bookDto);
        Task UpdateBookAsync(int id, CreateBookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
