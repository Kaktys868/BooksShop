using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class WishlistBookConfiguration : IEntityTypeConfiguration<WishlistBook>
    {
        public void Configure(EntityTypeBuilder<WishlistBook> builder)
        {
            builder.HasOne(wb => wb.Wishlist)
                .WithMany(w => w.WishlistBooks)
                .HasForeignKey(wb => wb.WishlistId);

            builder.HasOne(wb => wb.Book)
                .WithMany(b => b.WishlistBooks)
                .HasForeignKey(wb => wb.BookId);
        }
    }
}
