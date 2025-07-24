using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class WishlistBook
    {
        public int WishlistBookId { get; set; }
        public int WishlistId { get; set; }
        public int BookId { get; set; }
        
        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WishlistName { get; set; }
        public Book Book { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
