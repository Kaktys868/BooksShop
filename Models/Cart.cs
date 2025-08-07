using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CartQuantity { get; set; }
        public DateOnly CartDateAdd { get; set; }
        public int CartUserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }

        public ICollection<CartBook> CartBooks { get; set; } 
            = new List<CartBook>();

        public User User { get; set; }
    }
}
