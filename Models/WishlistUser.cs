using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class WishlistUser
    {
        public int WishlistUserId { get; set; }
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string WishlistName { get; set; }
        public User User { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
