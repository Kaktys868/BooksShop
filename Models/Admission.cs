using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class Admission
    {
        public int AdmissionId { get; set; }

        public int AdmissionQuantity { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public int AdmissionBookId { get; set; }

        public int AdmissionWarehouseId { get; set; }
        [NotMapped]
        public string BookName { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }

        public Book Book { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
