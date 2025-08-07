using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Wishlist;

namespace BooksShop.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _WishlistRepository;
        private readonly IMapper _mapper;

        public WishlistService(IWishlistRepository WishlistRepository, IMapper mapper)
        {
            _WishlistRepository = WishlistRepository;
            _mapper = mapper;
        }

        public async Task<WishlistDto> GetWishlistByIdAsync(int id)
        {
            var Wishlist = await _WishlistRepository.GetByIdAsync(id);
            return _mapper.Map<WishlistDto>(Wishlist);
        }

        public async Task<IEnumerable<WishlistDto>> GetAllWishlistAsync()
        {
            var Wishlists = await _WishlistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WishlistDto>>(Wishlists);
        }

        public async Task AddWishlistAsync(CreateWishlistDto WishlistDto)
        {
            var Wishlist = _mapper.Map<Models.Wishlist>(WishlistDto);
            await _WishlistRepository.AddAsync(Wishlist);
        }

        public async Task UpdateWishlistAsync(int id, CreateWishlistDto WishlistDto)
        {

            var Wishlist = await _WishlistRepository.GetByIdAsync(id);
            _mapper.Map(WishlistDto, Wishlist);
            await _WishlistRepository.UpdateAsync(Wishlist);
        }

        public async Task DeleteWishlistAsync(int id)
        {
            await _WishlistRepository.DeleteAsync(id);
        }
    }
}