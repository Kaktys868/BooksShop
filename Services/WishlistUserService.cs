using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.WishlistUser;

namespace BooksShop.Services
{
    public class WishlistUserService : IWishlistUserService
    {
        private readonly IWishlistUserRepository _WishlistUserRepository;
        private readonly IMapper _mapper;

        public WishlistUserService(IWishlistUserRepository WishlistUserRepository, IMapper mapper)
        {
            _WishlistUserRepository = WishlistUserRepository;
            _mapper = mapper;
        }

        public async Task<WishlistUserDto> GetWishlistUserByIdAsync(int id)
        {
            var WishlistUser = await _WishlistUserRepository.GetByIdAsync(id);
            return _mapper.Map<WishlistUserDto>(WishlistUser);
        }

        public async Task<IEnumerable<WishlistUserDto>> GetAllWishlistUserAsync()
        {
            var WishlistUsers = await _WishlistUserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WishlistUserDto>>(WishlistUsers);
        }

        public async Task AddWishlistUserAsync(CreateWishlistUserDto WishlistUserDto)
        {
            var WishlistUser = _mapper.Map<Models.WishlistUser>(WishlistUserDto);
            await _WishlistUserRepository.AddAsync(WishlistUser);
        }

        public async Task UpdateWishlistUserAsync(int id, CreateWishlistUserDto WishlistUserDto)
        {

            var WishlistUser = await _WishlistUserRepository.GetByIdAsync(id);
            _mapper.Map(WishlistUserDto, WishlistUser);
            await _WishlistUserRepository.UpdateAsync(WishlistUser);
        }

        public async Task DeleteWishlistUserAsync(int id)
        {
            await _WishlistUserRepository.DeleteAsync(id);
        }
    }
}