using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BooksShop.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFIO { get; set; }
        public DateOnly AuthorDateOfBorn { get; set; }
        public DateOnly AuthorDateOfDeath { get; set; }
            = new DateOnly(0001,01,01);

        public ICollection<AuthorBook> AuthorBooks { get; set; }
           = new List<AuthorBook>();
    }
}
