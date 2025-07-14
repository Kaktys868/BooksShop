namespace BooksShop.Models
{
    public class CartBook
    {
        public int CartBookId { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }

        public Cart Cart { get; set; }
        public Book Book { get; set; }
    }
}
