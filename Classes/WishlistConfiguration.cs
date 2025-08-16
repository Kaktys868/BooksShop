using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasMany(w => w.WishlistBooks)
                .WithOne(wb => wb.Wishlist)
                .HasForeignKey(wb => wb.WishlistId);

            builder.HasMany(w => w.WishlistUsers)
                .WithOne(wu => wu.Wishlist)
                .HasForeignKey(wu => wu.WishlistId);
        }
    }
}
