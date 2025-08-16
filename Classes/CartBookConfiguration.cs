using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class CartBookConfiguration : IEntityTypeConfiguration<CartBook>
    {
        public void Configure(EntityTypeBuilder<CartBook> builder)
        {
            builder.HasOne(cb => cb.Cart)
                .WithMany(c => c.CartBooks)
                .HasForeignKey(cb => cb.CartId);

            builder.HasOne(cb => cb.Book)
                .WithMany(b => b.CartBooks)
                .HasForeignKey(cb => cb.BookId);
        }
    }
}
