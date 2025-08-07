using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int CartQuantity { get; set; }
        public DateOnly CartDateAdd { get; set; }
        public int CartUserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
    public class CreateCartDto
    {
        public int CartQuantity { get; set; }
        public DateOnly CartDateAdd { get; set; }
        public int CartUserId { get; set; }
    }
}
