using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class WishlistUserConfiguration : IEntityTypeConfiguration<WishlistUser>
    {
        public void Configure(EntityTypeBuilder<WishlistUser> builder)
        {
            builder.HasOne(wu => wu.Wishlist)
                .WithMany(w => w.WishlistUsers)
                .HasForeignKey(wu => wu.WishlistId);

            builder.HasOne(wu => wu.User)
                .WithMany(u => u.WishlistUsers)
                .HasForeignKey(wu => wu.UserId);
        }
    }
}
