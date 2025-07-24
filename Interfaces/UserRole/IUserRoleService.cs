using BooksShop.DTO;

namespace BooksShop.Interfaces.UserRole
{
    public interface IUserRoleService
    {
        Task<UserRoleDto> GetUserRoleByIdAsync(int id);
        Task<IEnumerable<UserRoleDto>> GetAllUserRoleAsync();
        Task AddUserRoleAsync(CreateUserRoleDto userRoleDto);
        Task UpdateUserRoleAsync(int id, CreateUserRoleDto userRoleDto);
        Task DeleteUserRoleAsync(int id);
    }
}