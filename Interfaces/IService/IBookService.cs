using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBookAsync();
        Task AddBookAsync(CreateBookDto bookDto);
        Task UpdateBookAsync(int id, CreateBookDto bookDto);
        Task DeleteBookAsync(int id);
    }
}
