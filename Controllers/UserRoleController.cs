using BooksShop.DTO;
using BooksShop.Interfaces.UserRole;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/UserRoleController")]
    [ApiExplorerSettings(GroupName = "v17")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _UserRoleService;

        public UserRoleController(IUserRoleService UserRoleService)
        {
            _UserRoleService = UserRoleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDto>>> GetAllUserRole()
        {
            var UserRoles = await _UserRoleService.GetAllUserRoleAsync();
            return Ok(UserRoles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDto>> GetUserRole(int id)
        {
            var UserRole = await _UserRoleService.GetUserRoleByIdAsync(id);
            if (UserRole == null) return NotFound();
            return Ok(UserRole);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserRole([FromBody] CreateUserRoleDto UserRoleDto)
        {
            await _UserRoleService.AddUserRoleAsync(UserRoleDto);
            return CreatedAtAction(nameof(GetUserRole), UserRoleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserRole(int id, [FromBody] CreateUserRoleDto UserRoleDto)
        {
            await _UserRoleService.UpdateUserRoleAsync(id, UserRoleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserRole(int id)
        {
            await _UserRoleService.DeleteUserRoleAsync(id);
            return NoContent();
        }
    }
}