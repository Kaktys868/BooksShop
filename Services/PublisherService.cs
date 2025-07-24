using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Publisher;
using BooksShop.Models;

namespace BooksShop.Services
{
    public class PublisherService : Interfaces.Publisher.IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherDto> GetPublisherByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            return _mapper.Map<PublisherDto>(publisher);
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublisherAsync()
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
        }

        public async Task AddPublisherAsync(CreatePublisherDto publisherDto)
        {
            var publisher = _mapper.Map<Publisher>(publisherDto);
            await _publisherRepository.AddAsync(publisher);
        }

        public async Task UpdatePublisherAsync(int id, CreatePublisherDto publisherDto)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            _mapper.Map(publisherDto, publisher);
            await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task DeletePublisherAsync(int id)
        {
            await _publisherRepository.DeleteAsync(id);
        }
    }
}