namespace BooksShop.Models
{
    public class WishlistUser
    {
        public int WishlistUserId { get; set; }
        public int WishlistId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
