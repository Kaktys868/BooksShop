using AutoMapper;
using BooksShop.DTO;
using BooksShop.Interfaces.Review;

namespace BooksShop.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _ReviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository ReviewRepository, IMapper mapper)
        {
            _ReviewRepository = ReviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int id)
        {
            var Review = await _ReviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDto>(Review);
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewAsync()
        {
            var Reviews = await _ReviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(Reviews);
        }

        public async Task AddReviewAsync(CreateReviewDto ReviewDto)
        {
            var Review = _mapper.Map<Models.Review>(ReviewDto);
            await _ReviewRepository.AddAsync(Review);
        }

        public async Task UpdateReviewAsync(int id, CreateReviewDto ReviewDto)
        {

            var Review = await _ReviewRepository.GetByIdAsync(id);
            _mapper.Map(ReviewDto, Review);
            await _ReviewRepository.UpdateAsync(Review);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _ReviewRepository.DeleteAsync(id);
        }
    }
}