using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
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