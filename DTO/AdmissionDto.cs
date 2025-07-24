using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class AdmissionDto
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
    }
    public class CreateAdmissionDto
    {

        public int AdmissionQuantity { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public int AdmissionBookId { get; set; }

        public int AdmissionWarehouseId { get; set; }
    }
}
