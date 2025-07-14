namespace BooksShop.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublisherAddress { get; set; }
        public string PublisherPhoneNumber { get; set; }

        public ICollection<Book> Books { get; set; }
            = new List<Book>();
    }
}
