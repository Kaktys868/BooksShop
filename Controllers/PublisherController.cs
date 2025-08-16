using BooksShop.DTO;
using BooksShop.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/PublisherController")]
    [ApiExplorerSettings(GroupName = "v12")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublisherAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDto>> GetPublisher(int id)
        {
            var publisher = await _publisherService.GetPublisherByIdAsync(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult> AddPublisher([FromBody] CreatePublisherDto publisherDto)
        {
            await _publisherService.AddPublisherAsync(publisherDto);
            return CreatedAtAction(nameof(GetPublisher), publisherDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePublisher(int id, [FromBody] CreatePublisherDto publisherDto)
        {
            await _publisherService.UpdatePublisherAsync(id, publisherDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublisher(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            return NoContent();
        }
    }
}