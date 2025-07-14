namespace BooksShop.Models
{
    public class WarehouseBook
    {
        public int WarehouseBookId { get; set; }
        public int BookId { get; set; }
        public int WarehouseId { get; set; }

        public Book Book { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
