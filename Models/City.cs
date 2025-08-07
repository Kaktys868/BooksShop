using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
            = new List<Warehouse>();
    }
}
