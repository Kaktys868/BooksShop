using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Author;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository AuthorRepository, IMapper mapper)
        {
            _AuthorRepository = AuthorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var Author = await _AuthorRepository.GetByIdAsync(id);
            return _mapper.Map<AuthorDto>(Author);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync()
        {
            var Authors = await _AuthorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuthorDto>>(Authors);
        }

        public async Task AddAuthorAsync(CreateAuthorDto AuthorDto)
        {
            var Author = _mapper.Map<Author>(AuthorDto);
            await _AuthorRepository.AddAsync(Author);
        }

        public async Task UpdateAuthorAsync(int id, CreateAuthorDto AuthorDto)
        {

            var Author = await _AuthorRepository.GetByIdAsync(id);
            _mapper.Map(AuthorDto, Author);
            await _AuthorRepository.UpdateAsync(Author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _AuthorRepository.DeleteAsync(id);
        }
    }
}