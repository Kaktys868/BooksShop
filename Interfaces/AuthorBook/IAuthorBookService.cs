using BooksShop.DTO;

namespace BooksShop.Interfaces.AuthorBook
{
    public interface IAuthorBookService
    {
        Task<AuthorBookDto> GetAuthorBookByIdAsync(int id);
        Task<IEnumerable<AuthorBookDto>> GetAllAuthorBookAsync();
        Task AddAuthorBookAsync(CreateAuthorBookDto authorBookDto);
        Task UpdateAuthorBookAsync(int id, CreateAuthorBookDto authorBookDto);
        Task DeleteAuthorBookAsync(int id);
    }
}
