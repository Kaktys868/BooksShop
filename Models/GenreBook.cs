namespace BooksShop.Models
{
    public class GenreBook
    {
        public int GenreBookId { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
        public Book Book { get; set; }

    }
}
