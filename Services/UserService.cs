using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var User = await _UserRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(User);
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var Users = await _UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(Users);
        }

        public async Task AddUserAsync(CreateUserDto UserDto)
        {
            var User = _mapper.Map<Models.User>(UserDto);
            await _UserRepository.AddAsync(User);
        }

        public async Task UpdateUserAsync(int id, CreateUserDto UserDto)
        {

            var User = await _UserRepository.GetByIdAsync(id);
            _mapper.Map(UserDto, User);
            await _UserRepository.UpdateAsync(User);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _UserRepository.DeleteAsync(id);
        }
    }
}