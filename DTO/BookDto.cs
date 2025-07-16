using System.ComponentModel.DataAnnotations;

namespace BooksShop.DTO
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        public int BookSeries { get; set; }
        public int BookGenre { get; set; }
        public int BookPublisher { get; set; }
    }
    
    public class CreateBookDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateOnly BookDateDesign { get; set; }
        public int BookCost { get; set; }
        public int BookSeries { get; set; }
        public int BookGenre { get; set; }
        public int BookPublisher { get; set; }
    }
}