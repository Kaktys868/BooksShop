namespace BooksShop.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public DateOnly WishlistAddDate { get; set; }

        public ICollection<WishlistUser> WishlistUsers { get; set; }
            = new List<WishlistUser>();
        public ICollection<WishlistBook> WishlistBooks { get; set; }
            = new List<WishlistBook>();
    }
}
