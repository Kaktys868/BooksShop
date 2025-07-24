namespace BooksShop.DTO
{
    public class PublisherDto
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublisherAddress { get; set; }
        public string PublisherPhoneNumber { get; set; }
    }

    public class CreatePublisherDto
    {
        public string PublisherName { get; set; }
        public string PublisherAddress { get; set; }
        public string PublisherPhoneNumber { get; set; }
    }
}