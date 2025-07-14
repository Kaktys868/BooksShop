namespace BooksShop.Models
{
    public class Series
    {
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string SeriesDescription { get; set; }

        public ICollection<Book> Books { get; set; }
            = new List<Book>();
    }
}
