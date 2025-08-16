using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository RoleRepository, IMapper mapper)
        {
            _RoleRepository = RoleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var Role = await _RoleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDto>(Role);
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoleAsync()
        {
            var Roles = await _RoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(Roles);
        }

        public async Task AddRoleAsync(CreateRoleDto RoleDto)
        {
            var Role = _mapper.Map<Models.Role>(RoleDto);
            await _RoleRepository.AddAsync(Role);
        }

        public async Task UpdateRoleAsync(int id, CreateRoleDto RoleDto)
        {

            var Role = await _RoleRepository.GetByIdAsync(id);
            _mapper.Map(RoleDto, Role);
            await _RoleRepository.UpdateAsync(Role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _RoleRepository.DeleteAsync(id);
        }
    }
}