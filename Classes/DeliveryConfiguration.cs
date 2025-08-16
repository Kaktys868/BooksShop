using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasOne(d => d.Book)
                .WithMany(b => b.Deliveries)
                .HasForeignKey(d => d.DeliveryBookId);

            builder.HasOne(d => d.Warehouse)
                .WithMany(w => w.Deliveries)
                .HasForeignKey(d => d.DeliveryWarehouseId);
        }
    }
}
