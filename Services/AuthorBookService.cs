using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.AuthorBook;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _AuthorBookRepository;
        private readonly IMapper _mapper;

        public AuthorBookService(IAuthorBookRepository AuthorBookRepository, IMapper mapper)
        {
            _AuthorBookRepository = AuthorBookRepository;
            _mapper = mapper;
        }

        public async Task<AuthorBookDto> GetAuthorBookByIdAsync(int id)
        {
            var AuthorBook = await _AuthorBookRepository.GetByIdAsync(id);
            return _mapper.Map<AuthorBookDto>(AuthorBook);
        }

        public async Task<IEnumerable<AuthorBookDto>> GetAllAuthorBookAsync()
        {
            var AuthorBooks = await _AuthorBookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorBookDto>>(AuthorBooks);
        }

        public async Task AddAuthorBookAsync(CreateAuthorBookDto AuthorBookDto)
        {
            var AuthorBook = _mapper.Map<AuthorBook>(AuthorBookDto);
            await _AuthorBookRepository.AddAsync(AuthorBook);
        }

        public async Task UpdateAuthorBookAsync(int id, CreateAuthorBookDto AuthorBookDto)
        {

            var AuthorBook = await _AuthorBookRepository.GetByIdAsync(id);
            _mapper.Map(AuthorBookDto, AuthorBook);
            await _AuthorBookRepository.UpdateAsync(AuthorBook);
        }

        public async Task DeleteAuthorBookAsync(int id)
        {
            await _AuthorBookRepository.DeleteAsync(id);
        }
    }
}