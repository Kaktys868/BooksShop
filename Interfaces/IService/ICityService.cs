using BooksShop.DTO;

namespace BooksShop.Interfaces.IService
{
    public interface ICityService
    {
        Task<CityDto> GetCityByIdAsync(int id);
        Task<IEnumerable<CityDto>> GetAllCityAsync();
        Task AddCityAsync(CreateCityDto cityDto);
        Task UpdateCityAsync(int id, CreateCityDto cityDto);
        Task DeleteCityAsync(int id);
    }
}