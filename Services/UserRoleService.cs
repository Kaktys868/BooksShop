using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository UserRoleRepository, IMapper mapper)
        {
            _UserRoleRepository = UserRoleRepository;
            _mapper = mapper;
        }

        public async Task<UserRoleDto> GetUserRoleByIdAsync(int id)
        {
            var UserRole = await _UserRoleRepository.GetByIdAsync(id);
            return _mapper.Map<UserRoleDto>(UserRole);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAllUserRoleAsync()
        {
            var UserRoles = await _UserRoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRoleDto>>(UserRoles);
        }

        public async Task AddUserRoleAsync(CreateUserRoleDto UserRoleDto)
        {
            var UserRole = _mapper.Map<Models.UserRole>(UserRoleDto);
            await _UserRoleRepository.AddAsync(UserRole);
        }

        public async Task UpdateUserRoleAsync(int id, CreateUserRoleDto UserRoleDto)
        {

            var UserRole = await _UserRoleRepository.GetByIdAsync(id);
            _mapper.Map(UserRoleDto, UserRole);
            await _UserRoleRepository.UpdateAsync(UserRole);
        }

        public async Task DeleteUserRoleAsync(int id)
        {
            await _UserRoleRepository.DeleteAsync(id);
        }
    }
}