using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class DeliveryDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryQuantity { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int DeliveryBookId { get; set; }
        public int DeliveryWarehouseId { get; set; }


        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }
    }
    public class CreateDeliveryDto
    {
        public int DeliveryQuantity { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public int DeliveryBookId { get; set; }
        public int DeliveryWarehouseId { get; set; }
    }
}
