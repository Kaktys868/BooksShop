using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _WarehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository WarehouseRepository, IMapper mapper)
        {
            _WarehouseRepository = WarehouseRepository;
            _mapper = mapper;
        }

        public async Task<WarehouseDto> GetWarehouseByIdAsync(int id)
        {
            var Warehouse = await _WarehouseRepository.GetByIdAsync(id);
            return _mapper.Map<WarehouseDto>(Warehouse);
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllWarehouseAsync()
        {
            var Warehouses = await _WarehouseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseDto>>(Warehouses);
        }

        public async Task AddWarehouseAsync(CreateWarehouseDto WarehouseDto)
        {
            var Warehouse = _mapper.Map<BooksShop.Models.Warehouse>(WarehouseDto);
            await _WarehouseRepository.AddAsync(Warehouse);
        }

        public async Task UpdateWarehouseAsync(int id, CreateWarehouseDto WarehouseDto)
        {

            var Warehouse = await _WarehouseRepository.GetByIdAsync(id);
            _mapper.Map(WarehouseDto, Warehouse);
            await _WarehouseRepository.UpdateAsync(Warehouse);
        }

        public async Task DeleteWarehouseAsync(int id)
        {
            await _WarehouseRepository.DeleteAsync(id);
        }
    }
}