using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Infrastructure.Configurations.Inventory
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.ToTable("Lots");

            builder.Property(x => x.LotNumber)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .HasPrecision(18, 2)
                  .IsRequired();
            
            builder.Property(x => x.ExpirationDate)
                  .IsRequired(false);

            builder.Property(x => x.ProductionDate)
                  .IsRequired(false);

            builder.Property(x => x.Cost)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.HasOne(x=>x.Supplier)
                .WithMany(x=>x.Lots)
                .HasForeignKey(x=>x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.Lots)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            //AUDITABLE PROPERTIES

            builder.Property(x => x.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.UpdatedBy)
                   .IsRequired(false)
                   .HasMaxLength(50);

            builder.Property(x => x.CreatedAt)
                   .IsRequired();

            builder.Property(x => x.UpdatedAt)
                   .IsRequired(false);
        }
    }
}
