using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class WarehouseBookConfiguration : IEntityTypeConfiguration<WarehouseBook>
    {
        public void Configure(EntityTypeBuilder<WarehouseBook> builder)
        {
            builder.HasOne(wb => wb.Warehouse)
                .WithMany(w => w.WarehouseBooks)
                .HasForeignKey(wb => wb.WarehouseId);

            builder.HasOne(wb => wb.Book)
                .WithMany(b => b.WarehouseBooks)
                .HasForeignKey(wb => wb.BookId);
        }
    }
}
