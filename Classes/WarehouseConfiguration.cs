using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Classes
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasMany(w => w.Admissions)
                .WithOne(a => a.Warehouse)
                .HasForeignKey(a => a.AdmissionWarehouseId);

            builder.HasMany(w => w.Deliveries)
                .WithOne(d => d.Warehouse)
                .HasForeignKey(d => d.DeliveryWarehouseId);

            builder.HasMany(w => w.WarehouseBooks)
                .WithOne(wb => wb.Warehouse)
                .HasForeignKey(wb => wb.WarehouseId);

            builder.HasOne(w => w.City)
                .WithMany(c => c.Warehouses)
                .HasForeignKey(w => w.WarehouseCityId);
        }
    }
}
