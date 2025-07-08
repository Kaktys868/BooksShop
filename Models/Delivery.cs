namespace BooksShop.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int DeliveryQuantity { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int DeliveryBookId { get; set; }
        public int DeliveryWarehouseId { get; set; }
    }
}
