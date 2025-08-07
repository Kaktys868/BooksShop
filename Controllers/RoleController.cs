using BooksShop.DTO;
using BooksShop.Interfaces.Role;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/RoleController")]
    [ApiExplorerSettings(GroupName = "v14")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;

        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAllRole()
        {
            var Role = await _RoleService.GetAllRoleAsync();
            return Ok(Role);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var Role = await _RoleService.GetRoleByIdAsync(id);
            if (Role == null) return NotFound();
            return Ok(Role);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole([FromBody] CreateRoleDto RoleDto)
        {
            await _RoleService.AddRoleAsync(RoleDto);
            return CreatedAtAction(nameof(GetRole), RoleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(int id, [FromBody] CreateRoleDto RoleDto)
        {
            await _RoleService.UpdateRoleAsync(id, RoleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            await _RoleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}