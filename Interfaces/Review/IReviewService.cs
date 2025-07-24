using BooksShop.DTO;

namespace BooksShop.Interfaces.Review
{
    public interface IReviewService
    {
        Task<ReviewDto> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllReviewAsync();
        Task AddReviewAsync(CreateReviewDto reviewDto);
        Task UpdateReviewAsync(int id, CreateReviewDto reviewDto);
        Task DeleteReviewAsync(int id);
    }
}