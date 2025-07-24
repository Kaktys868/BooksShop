using System.ComponentModel.DataAnnotations.Schema;
namespace BooksShop.Models
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        [NotMapped]
        public string BookName { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
