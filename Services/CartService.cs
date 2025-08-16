using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _CartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository CartRepository, IMapper mapper)
        {
            _CartRepository = CartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByIdAsync(int id)
        {
            var Cart = await _CartRepository.GetByIdAsync(id);
            return _mapper.Map<CartDto>(Cart);
        }

        public async Task<IEnumerable<CartDto>> GetAllCartAsync()
        {
            var Carts = await _CartRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CartDto>>(Carts);
        }

        public async Task AddCartAsync(CreateCartDto CartDto)
        {
            var Cart = _mapper.Map<Models.Cart>(CartDto);
            await _CartRepository.AddAsync(Cart);
        }

        public async Task UpdateCartAsync(int id, CreateCartDto CartDto)
        {

            var Cart = await _CartRepository.GetByIdAsync(id);
            _mapper.Map(CartDto, Cart);
            await _CartRepository.UpdateAsync(Cart);
        }

        public async Task DeleteCartAsync(int id)
        {
            await _CartRepository.DeleteAsync(id);
        }
    }
}