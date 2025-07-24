using BooksShop.DTO;

namespace BooksShop.Interfaces.Author
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync();
        Task AddAuthorAsync(CreateAuthorDto authorDto);
        Task UpdateAuthorAsync(int id, CreateAuthorDto authorDto);
        Task DeleteAuthorAsync(int id);
    }
}
