using BooksShop.DTO;
using BooksShop.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/UserController")]
    [ApiExplorerSettings(GroupName = "v16")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUser()
        {
            var Users = await _UserService.GetAllUserAsync();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var User = await _UserService.GetUserByIdAsync(id);
            if (User == null) return NotFound();
            return Ok(User);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] CreateUserDto UserDto)
        {
            await _UserService.AddUserAsync(UserDto);
            return CreatedAtAction(nameof(GetUser), UserDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] CreateUserDto UserDto)
        {
            await _UserService.UpdateUserAsync(id, UserDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _UserService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}