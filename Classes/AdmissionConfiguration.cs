using BooksShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksShop.Data.Configurations
{
    public class AdmissionConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.HasOne(a => a.Book)
                .WithMany(b => b.Admissions)
                .HasForeignKey(a => a.AdmissionBookId);
            builder.HasOne(a => a.Warehouse)
                .WithMany(w => w.Admissions)
                .HasForeignKey(a => a.AdmissionWarehouseId);
        }
    }
}