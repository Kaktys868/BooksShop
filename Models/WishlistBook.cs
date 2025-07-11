namespace BooksShop.Models
{
    public class WishlistBook
    {
        public int WishlistBookId { get; set; }
        public int WishlistId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
