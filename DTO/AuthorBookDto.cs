using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class AuthorBookDto
    {
        public int AuthorBookId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        [NotMapped]
        public string BookName { get; set; }
    }
    public class CreateAuthorBookDto
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
