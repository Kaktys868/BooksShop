using BooksShop.DTO;

namespace BooksShop.Interfaces.Series
{
    public interface ISeriesService
    {
        Task<SeriesDto> GetSeriesByIdAsync(int id);
        Task<IEnumerable<SeriesDto>> GetAllSeriesAsync();
        Task AddSeriesAsync(CreateSeriesDto seriesDto);
        Task UpdateSeriesAsync(int id, CreateSeriesDto seriesDto);
        Task DeleteSeriesAsync(int id);
    }
}
