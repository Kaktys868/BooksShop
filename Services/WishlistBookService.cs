using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.WishlistBook;

namespace BooksShop.Services
{
    public class WishlistBookService : IWishlistBookService
    {
        private readonly IWishlistBookRepository _WishlistBookRepository;
        private readonly IMapper _mapper;

        public WishlistBookService(IWishlistBookRepository WishlistBookRepository, IMapper mapper)
        {
            _WishlistBookRepository = WishlistBookRepository;
            _mapper = mapper;
        }

        public async Task<WishlistBookDto> GetWishlistBookByIdAsync(int id)
        {
            var WishlistBook = await _WishlistBookRepository.GetByIdAsync(id);
            return _mapper.Map<WishlistBookDto>(WishlistBook);
        }

        public async Task<IEnumerable<WishlistBookDto>> GetAllWishlistBookAsync()
        {
            var WishlistBooks = await _WishlistBookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WishlistBookDto>>(WishlistBooks);
        }

        public async Task AddWishlistBookAsync(CreateWishlistBookDto WishlistBookDto)
        {
            var WishlistBook = _mapper.Map<Models.WishlistBook>(WishlistBookDto);
            await _WishlistBookRepository.AddAsync(WishlistBook);
        }

        public async Task UpdateWishlistBookAsync(int id, CreateWishlistBookDto WishlistBookDto)
        {

            var WishlistBook = await _WishlistBookRepository.GetByIdAsync(id);
            _mapper.Map(WishlistBookDto, WishlistBook);
            await _WishlistBookRepository.UpdateAsync(WishlistBook);
        }

        public async Task DeleteWishlistBookAsync(int id)
        {
            await _WishlistBookRepository.DeleteAsync(id);
        }
    }
}