using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.DTO
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorFIO { get; set; }
        public DateOnly AuthorDateOfBorn { get; set; }
        public DateOnly? AuthorDateOfDeath { get; set; }
    }
    public class CreateAuthorDto
    {
        public string AuthorFIO { get; set; }
        public DateOnly AuthorDateOfBorn { get; set; }
        public DateOnly? AuthorDateOfDeath { get; set; }
    }
}
