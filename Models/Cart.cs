namespace BooksShop.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string CartQuantity { get; set; }
        public DateOnly CartDateAdd { get; set; }
        public int CartUserId { get; set; }

        public ICollection<CartBook> CartBooks { get; set; } 
            = new List<CartBook>();

        public User User { get; set; }
    }
}
