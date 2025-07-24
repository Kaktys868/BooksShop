using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class WishlistUserDto
    {
        public int WishlistUserId { get; set; }
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string WishlistName { get; set; }
    }
    public class CreateWishlistUserDto
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
    }
}
