namespace BooksShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateOnly OrderCreateDate { get; set; }
        public DateOnly OrderDeliveryDate { get; set; }
        public int OrderBookQuantity { get; set; }
        public bool OrderBool { get; set; }
        public int OrderBookId { get; set; }
        public int OrderUserId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}
