using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class GenreBookConfiguration : IEntityTypeConfiguration<GenreBook>
    {
        public void Configure(EntityTypeBuilder<GenreBook> builder)
        {
            builder.HasOne(gb => gb.Genre)
                .WithMany(g => g.GenreBooks)
                .HasForeignKey(gb => gb.GenreId);

            builder.HasOne(gb => gb.Book)
                .WithMany(b => b.GenreBooks)
                .HasForeignKey(gb => gb.BookId);
        }
    }
}
