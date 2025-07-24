using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.CartBook;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class CartBookService : ICartBookService
    {
        private readonly ICartBookRepository _CartBookRepository;
        private readonly IMapper _mapper;

        public CartBookService(ICartBookRepository CartBookRepository, IMapper mapper)
        {
            _CartBookRepository = CartBookRepository;
            _mapper = mapper;
        }

        public async Task<CartBookDto> GetCartBookByIdAsync(int id)
        {
            var CartBook = await _CartBookRepository.GetByIdAsync(id);
            return _mapper.Map<CartBookDto>(CartBook);
        }

        public async Task<IEnumerable<CartBookDto>> GetAllCartBookAsync()
        {
            var CartBooks = await _CartBookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CartBookDto>>(CartBooks);
        }

        public async Task AddCartBookAsync(CreateCartBookDto CartBookDto)
        {
            var CartBook = _mapper.Map<CartBook>(CartBookDto);
            await _CartBookRepository.AddAsync(CartBook);
        }

        public async Task UpdateCartBookAsync(int id, CreateCartBookDto CartBookDto)
        {

            var CartBook = await _CartBookRepository.GetByIdAsync(id);
            _mapper.Map(CartBookDto, CartBook);
            await _CartBookRepository.UpdateAsync(CartBook);
        }

        public async Task DeleteCartBookAsync(int id)
        {
            await _CartBookRepository.DeleteAsync(id);
        }
    }
}