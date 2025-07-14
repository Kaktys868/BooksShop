namespace BooksShop.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public int WarehouseBooksQuantity { get; set; }
        public string WarehouseName { get; set; }
        public int WarehouseCityId { get; set; }

        public ICollection<Admission> Admissions { get; set; }
            = new List<Admission>();
        public ICollection<Delivery> Deliveries { get; set; }
            = new List<Delivery>();
        public ICollection<WarehouseBook> WarehouseBooks { get; set; }
            = new List<WarehouseBook>(); 
        public City City { get; set; }

    }
}
