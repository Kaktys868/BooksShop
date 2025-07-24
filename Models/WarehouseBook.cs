using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class WarehouseBook
    {
        public int WarehouseBookId { get; set; }
        public int BookId { get; set; }
        public int WarehouseId { get; set; }
        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }
        public Book Book { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
