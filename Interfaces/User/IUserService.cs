using BooksShop.DTO;

namespace BooksShop.Interfaces.User
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task AddUserAsync(CreateUserDto userDto);
        Task UpdateUserAsync(int id, CreateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}