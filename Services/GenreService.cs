using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Genre;
using BooksShop.Interfaces.Series;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreDto> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return _mapper.Map<GenreDto>(genre);
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenreAsync()
        {
            var genre = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDto>>(genre);
        }

        public async Task AddGenreAsync(CreateGenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreRepository.AddAsync(genre);
        }

        public async Task UpdateGenreAsync(int id, CreateGenreDto genreDto)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            _mapper.Map(genreDto, genre);
            await _genreRepository.UpdateAsync(genre);
        }

        public async Task DeleteGenreAsync(int id)
        {
            await _genreRepository.DeleteAsync(id);
        }
    }
}