using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class WishlistBookDto
    {
        public int WishlistBookId { get; set; }

        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WishlistName { get; set; }
    }
    public class CreateWishlistBookDto
    {
        public int WishlistId { get; set; }
        public int BookId { get; set; }
    }
}
