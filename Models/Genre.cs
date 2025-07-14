namespace BooksShop.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }


        public ICollection<GenreBook> GenreBooks { get; set; }
            = new List<GenreBook>();
    }
}
