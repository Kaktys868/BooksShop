using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateOnly OrderCreateDate { get; set; }
        public DateOnly OrderDeliveryDate { get; set; }
        public int OrderBookQuantity { get; set; }
        public int OrderBookId { get; set; }
        public int OrderUserId { get; set; }


        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
    public class CreateOrderDto
    {
        public DateOnly OrderCreateDate { get; set; }
        public DateOnly OrderDeliveryDate { get; set; }
        public int OrderBookQuantity { get; set; }
        public int OrderBookId { get; set; }
        public int OrderUserId { get; set; }
    }
}
