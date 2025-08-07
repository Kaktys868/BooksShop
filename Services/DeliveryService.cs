using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Delivery;

namespace BooksShop.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _DeliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository DeliveryRepository, IMapper mapper)
        {
            _DeliveryRepository = DeliveryRepository;
            _mapper = mapper;
        }

        public async Task<DeliveryDto> GetDeliveryByIdAsync(int id)
        {
            var Delivery = await _DeliveryRepository.GetByIdAsync(id);
            return _mapper.Map<DeliveryDto>(Delivery);
        }

        public async Task<IEnumerable<DeliveryDto>> GetAllDeliveryAsync()
        {
            var Deliverys = await _DeliveryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryDto>>(Deliverys);
        }

        public async Task AddDeliveryAsync(CreateDeliveryDto DeliveryDto)
        {
            var Delivery = _mapper.Map<Models.Delivery>(DeliveryDto);
            await _DeliveryRepository.AddAsync(Delivery);
        }

        public async Task UpdateDeliveryAsync(int id, CreateDeliveryDto DeliveryDto)
        {

            var Delivery = await _DeliveryRepository.GetByIdAsync(id);
            _mapper.Map(DeliveryDto, Delivery);
            await _DeliveryRepository.UpdateAsync(Delivery);
        }

        public async Task DeleteDeliveryAsync(int id)
        {
            await _DeliveryRepository.DeleteAsync(id);
        }
    }
}