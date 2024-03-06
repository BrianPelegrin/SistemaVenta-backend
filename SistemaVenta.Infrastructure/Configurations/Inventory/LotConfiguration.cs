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

            builder.Property(x => x.BarCode)
                   .HasMaxLength(100);

            builder.Property(x => x.Quantity)
                  .IsRequired();
            
            builder.Property(x => x.ExpirationDate)
                  .IsRequired();

            builder.Property(x => x.ProductionDate)
                  .IsRequired(false);

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.HasOne(x=>x.Supplier)
                .WithMany(x=>x.Lots)
                .HasForeignKey(x=>x.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.Lots)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

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
