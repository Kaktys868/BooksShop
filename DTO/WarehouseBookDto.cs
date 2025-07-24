using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class WarehouseBookDto
    {
        public int WarehouseBookId { get; set; }
        public int BookId { get; set; }
        public int WarehouseId { get; set; }
        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }
    }
    public class CreateWarehouseBookDto
    {
        public int BookId { get; set; }
        public int WarehouseId { get; set; }
    }
}
