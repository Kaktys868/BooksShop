namespace BooksShop.Models
{
    public class Admission
    {
        public int AdmissionId { get; set; }

        public int AdmissionQuantity { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public int AdmissionBookId { get; set; }

        public int AdmissionWarehouseId { get; set; }
    }
}
