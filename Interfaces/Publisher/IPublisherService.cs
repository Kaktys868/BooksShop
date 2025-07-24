using BooksShop.DTO;

namespace BooksShop.Interfaces.Publisher
{
    public interface IPublisherService
    {
        Task<PublisherDto> GetPublisherByIdAsync(int id);
        Task<IEnumerable<PublisherDto>> GetAllPublisherAsync();
        Task AddPublisherAsync(CreatePublisherDto publisherDto);
        Task UpdatePublisherAsync(int id, CreatePublisherDto publisherDto);
        Task DeletePublisherAsync(int id);
    }
}
