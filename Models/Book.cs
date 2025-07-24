using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        public int BookSeries { get; set; }
        public int BookPublisher { get; set; }

        [NotMapped]
        public string SeriesName { get; set; }
        [NotMapped]
        public string PublisherName { get; set; }
        [NotMapped]
        public string GenreName { get; set; }

        public ICollection<WishlistBook> WishlistBooks { get; set; }
            = new List<WishlistBook>();
        public ICollection<Review> Reviews { get; set; }
            = new List<Review>();
        public ICollection<CartBook> CartBooks { get; set; }
            = new List<CartBook>();
        public ICollection<Order> Orders { get; set; }
            = new List<Order>();
        public ICollection<AuthorBook> AuthorBooks { get; set; }
            = new List<AuthorBook>();
        public ICollection<GenreBook> GenreBooks { get; set; }
            = new List<GenreBook>();
        public ICollection<Admission> Admissions { get; set; }
            = new List<Admission>();
        public ICollection<Delivery> Deliveries { get; set; }
            = new List<Delivery>();
        public ICollection<WarehouseBook> WarehouseBooks { get; set; }
            = new List<WarehouseBook>();

        public Series Series { get; set; }
        public Publisher Publishers { get; set; }

    }
}
