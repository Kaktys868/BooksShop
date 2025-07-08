namespace BooksShop.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public DateOnly WishlistAddDate { get; set; }
        public int WishlistBookId { get; set; }
        public int WishlistUserId { get; set; }

    }
}
