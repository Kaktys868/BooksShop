using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class CartBookDto
    {
        public int CartBookId { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        [NotMapped]
        public string CartUserName { get; set; }
        [NotMapped]
        public string BookName { get; set; }
    }
    public class CreateCartBookDto
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
    }
}
