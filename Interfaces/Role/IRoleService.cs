using BooksShop.DTO;

namespace BooksShop.Interfaces.Role
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleDto>> GetAllRoleAsync();
        Task AddRoleAsync(CreateRoleDto roleDto);
        Task UpdateRoleAsync(int id, CreateRoleDto roleDto);
        Task DeleteRoleAsync(int id);
    }
}
