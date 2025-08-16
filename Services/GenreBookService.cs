using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class GenreBookService : IGenreBookService
    {
        private readonly IGenreBookRepository _genreBookRepository;
        private readonly IMapper _mapper;

        public GenreBookService(IGenreBookRepository genreBookRepository, IMapper mapper)
        {
            _genreBookRepository = genreBookRepository;
            _mapper = mapper;
        }

        public async Task<GenreBookDto> GetGenreBookByIdAsync(int id)
        {
            var genreBook = await _genreBookRepository.GetByIdAsync(id);
            return _mapper.Map<GenreBookDto>(genreBook);
        }

        public async Task<IEnumerable<GenreBookDto>> GetAllGenreBookAsync()
        {
            var genreBook = await _genreBookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreBookDto>>(genreBook);
        }

        public async Task AddGenreBookAsync(CreateGenreBookDto genreBookDto)
        {
            var genreBook = _mapper.Map<GenreBook>(genreBookDto);
            await _genreBookRepository.AddAsync(genreBook);
        }

        public async Task UpdateGenreBookAsync(int id, CreateGenreBookDto genreBookDto)
        {

            var genreBook = await _genreBookRepository.GetByIdAsync(id);
            _mapper.Map(genreBookDto, genreBook);
            await _genreBookRepository.UpdateAsync(genreBook);
        }

        public async Task DeleteGenreBookAsync(int id)
        {
            await _genreBookRepository.DeleteAsync(id);
        }
    }
}