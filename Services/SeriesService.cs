using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces;
using BooksShop.Interfaces.Series;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public SeriesService(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<SeriesDto> GetSeriesByIdAsync(int id)
        {
            var series = await _seriesRepository.GetByIdAsync(id);
            return _mapper.Map<SeriesDto>(series);
        }

        public async Task<IEnumerable<SeriesDto>> GetAllSeriesAsync()
        {
            var seriess = await _seriesRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SeriesDto>>(seriess);
        }

        public async Task AddSeriesAsync(CreateSeriesDto seriesDto)
        {
            var series = _mapper.Map<Series>(seriesDto);
            await _seriesRepository.AddAsync(series);
        }

        public async Task UpdateSeriesAsync(int id, CreateSeriesDto seriesDto)
        {
            var series = await _seriesRepository.GetByIdAsync(id);
            _mapper.Map(seriesDto, series);
            await _seriesRepository.UpdateAsync(series);
        }

        public async Task DeleteSeriesAsync(int id)
        {
            await _seriesRepository.DeleteAsync(id);
        }
    }
}