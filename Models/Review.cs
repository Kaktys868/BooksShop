namespace BooksShop.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ReviewText { get; set; }
        public int ReviewRating { get; set; }
        public DateOnly ReviewDate { get; set; }
        public int ReviewBookId { get; set; }
        public int ReviewUserId { get; set; }
    }
}
