using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.City;

namespace BooksShop.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> GetCityByIdAsync(int id)
        {
            var City = await _CityRepository.GetByIdAsync(id);
            return _mapper.Map<CityDto>(City);
        }

        public async Task<IEnumerable<CityDto>> GetAllCityAsync()
        {
            var Citys = await _CityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CityDto>>(Citys);
        }

        public async Task AddCityAsync(CreateCityDto CityDto)
        {
            var City = _mapper.Map<Models.City>(CityDto);
            await _CityRepository.AddAsync(City);
        }

        public async Task UpdateCityAsync(int id, CreateCityDto CityDto)
        {

            var City = await _CityRepository.GetByIdAsync(id);
            _mapper.Map(CityDto, City);
            await _CityRepository.UpdateAsync(City);
        }

        public async Task DeleteCityAsync(int id)
        {
            await _CityRepository.DeleteAsync(id);
        }
    }
}