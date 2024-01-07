using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Infrastructure.Configurations.Inventory
{
    public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
    {
        public void Configure(EntityTypeBuilder<InventoryMovement> builder)
        {
            builder.ToTable("InventoryMovements");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.NewValue)
                   .IsRequired();
            
            builder.Property(x => x.OldValue)
                   .IsRequired();

            builder.Property(x => x.AffectedQuantity)
                   .IsRequired();

            builder.Property(x => x.ProductId)
                   .IsRequired();

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.InventoryMovements)
                   .HasForeignKey(x => x.ProductId);

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
