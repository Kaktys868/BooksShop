using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Order;

namespace BooksShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var Order = await _OrderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(Order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrderAsync()
        {
            var Orders = await _OrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(Orders);
        }

        public async Task AddOrderAsync(CreateOrderDto OrderDto)
        {
            var Order = _mapper.Map<Models.Order>(OrderDto);
            await _OrderRepository.AddAsync(Order);
        }

        public async Task UpdateOrderAsync(int id, CreateOrderDto OrderDto)
        {

            var Order = await _OrderRepository.GetByIdAsync(id);
            _mapper.Map(OrderDto, Order);
            await _OrderRepository.UpdateAsync(Order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _OrderRepository.DeleteAsync(id);
        }
    }
}