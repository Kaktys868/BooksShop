using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        [NotMapped]
        public string SeriesName { get; set; }
        [NotMapped]
        public string PublisherName { get; set; }
        [NotMapped]
        public string GenreName { get; set; }
        [NotMapped]
        public string AuthorNames { get; set; }
    }
    
    public class CreateBookDto
    {
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        public int BookSeries { get; set; }
        public int BookPublisher { get; set; }
    }
}