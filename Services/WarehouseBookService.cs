using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.IRepository;
using BooksShop.Interfaces.IService;

namespace BooksShop.Services
{
    public class WarehouseBookService : IWarehouseBookService
    {
        private readonly IWarehouseBookRepository _WarehouseBookRepository;
        private readonly IMapper _mapper;

        public WarehouseBookService(IWarehouseBookRepository WarehouseBookRepository, IMapper mapper)
        {
            _WarehouseBookRepository = WarehouseBookRepository;
            _mapper = mapper;
        }

        public async Task<WarehouseBookDto> GetWarehouseBookByIdAsync(int id)
        {
            var WarehouseBook = await _WarehouseBookRepository.GetByIdAsync(id);
            return _mapper.Map<WarehouseBookDto>(WarehouseBook);
        }

        public async Task<IEnumerable<WarehouseBookDto>> GetAllWarehouseBookAsync()
        {
            var WarehouseBooks = await _WarehouseBookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WarehouseBookDto>>(WarehouseBooks);
        }

        public async Task AddWarehouseBookAsync(CreateWarehouseBookDto WarehouseBookDto)
        {
            var WarehouseBook = _mapper.Map<Models.WarehouseBook>(WarehouseBookDto);
            await _WarehouseBookRepository.AddAsync(WarehouseBook);
        }

        public async Task UpdateWarehouseBookAsync(int id, CreateWarehouseBookDto WarehouseBookDto)
        {

            var WarehouseBook = await _WarehouseBookRepository.GetByIdAsync(id);
            _mapper.Map(WarehouseBookDto, WarehouseBook);
            await _WarehouseBookRepository.UpdateAsync(WarehouseBook);
        }

        public async Task DeleteWarehouseBookAsync(int id)
        {
            await _WarehouseBookRepository.DeleteAsync(id);
        }
    }
}