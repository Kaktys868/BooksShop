using BooksShop.DTO;
using BooksShop.Interfaces.Review;
using Microsoft.AspNetCore.Mvc;

namespace BooksShop.Controllers
{
    [Route("api/ReviewController")]
    [ApiExplorerSettings(GroupName = "v13")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _ReviewService;

        public ReviewController(IReviewService ReviewService)
        {
            _ReviewService = ReviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReview()
        {
            var Review = await _ReviewService.GetAllReviewAsync();
            return Ok(Review);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview(int id)
        {
            var Review = await _ReviewService.GetReviewByIdAsync(id);
            if (Review == null) return NotFound();
            return Ok(Review);
        }

        [HttpPost]
        public async Task<ActionResult> AddReview([FromBody] CreateReviewDto ReviewDto)
        {
            await _ReviewService.AddReviewAsync(ReviewDto);
            return CreatedAtAction(nameof(GetReview), ReviewDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(int id, [FromBody] CreateReviewDto ReviewDto)
        {
            await _ReviewService.UpdateReviewAsync(id, ReviewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _ReviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}