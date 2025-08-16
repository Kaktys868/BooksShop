using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Admissions)
           .WithOne(a => a.Book)
           .HasForeignKey(a => a.AdmissionBookId);

            builder.HasMany(b => b.CartBooks)
                .WithOne(cb => cb.Book)
                .HasForeignKey(cb => cb.BookId);

            builder.HasMany(b => b.Orders)
                .WithOne(o => o.Book)
                .HasForeignKey(o => o.OrderBookId);

            builder.HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.ReviewBookId);

            builder.HasMany(b => b.WarehouseBooks)
                .WithOne(wb => wb.Book)
                .HasForeignKey(wb => wb.BookId);

            builder.HasMany(b => b.WishlistBooks)
                .WithOne(wb => wb.Book)
                .HasForeignKey(wb => wb.BookId);

            builder.HasMany(b => b.Deliveries)
                .WithOne(d => d.Book)
                .HasForeignKey(d => d.DeliveryBookId);

            builder.HasOne(b => b.Series)
                .WithMany(s => s.Books)
                .HasForeignKey(b => b.BookSeries);

            builder.HasOne(b => b.Publishers)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.BookPublisher);
        }
    }
}
