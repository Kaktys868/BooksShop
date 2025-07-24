using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class Delivery
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

        public Book Book { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
