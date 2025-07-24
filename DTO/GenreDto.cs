namespace BooksShop.DTO
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }

    }
    public class CreateGenreDto
    {
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
