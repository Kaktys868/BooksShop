namespace BooksShop.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public DateOnly WishlistAddDate { get; set; }

        public ICollection<WishlistUser> WishlistUsers { get; set; }
        public ICollection<WishlistBook> WishlistBooks { get; set; }

        public Wishlist()
        {
            WishlistUsers = new List<WishlistUser>();
            WishlistBooks = new List<WishlistBook>();
        }

    }
}
