using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public int WarehouseBooksQuantity { get; set; }
        public string WarehouseName { get; set; }

        [NotMapped]
        public string CityName { get; set; }
    }
    public class CreateWarehouseDto
    {
        public int WarehouseBooksQuantity { get; set; }
        public string WarehouseName { get; set; }
        public int WarehouseCityId { get; set; }
    }
}
