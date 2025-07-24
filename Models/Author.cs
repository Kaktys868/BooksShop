using BooksShop.Classes.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksShop.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFIO { get; set; }
        public DateOnly AuthorDateOfBorn { get; set; }
        public DateOnly? AuthorDateOfDeath { get; set; } = null;

        public ICollection<AuthorBook> AuthorBooks { get; set; }
           = new List<AuthorBook>();
    }
}
