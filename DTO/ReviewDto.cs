using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int ReviewText { get; set; }
        public int ReviewRating { get; set; }
        public DateOnly ReviewDate { get; set; }
        public int ReviewBookId { get; set; }
        public int ReviewUserId { get; set; }

        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
    public class CreateReviewDto
    {
        public int ReviewText { get; set; }
        public int ReviewRating { get; set; }
        public DateOnly ReviewDate { get; set; }
        public int ReviewBookId { get; set; }
        public int ReviewUserId { get; set; }
    }
}
