using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class GenreBookDto
    {
        public int GenreBookId { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        [NotMapped]
        public string GenreName { get; set; }
        [NotMapped]
        public string BookName { get; set; }
    }

    public class CreateGenreBookDto
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
