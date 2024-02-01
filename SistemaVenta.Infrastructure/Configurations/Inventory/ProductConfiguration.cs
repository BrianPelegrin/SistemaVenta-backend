using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Infrastructure.Configurations.Inventory
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name)
                   .HasMaxLength(100)                   
                   .IsRequired();            

            builder.Property(x => x.Description)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Stock)
                   .IsRequired();

            builder.Property(x => x.MinimalStock)
                   .IsRequired();

            builder.Property(x=>x.SalePrice)
                   .IsRequired()
                   .HasPrecision(18,2);
            
            builder.Property(x=>x.PurchasePrice)
                   .IsRequired()
                   .HasPrecision(18,2);

            builder.Property(x => x.BarCode)
                   .IsRequired(false)
                   .HasMaxLength(13);

            builder.Property(x => x.CategoryId)
                   .IsRequired();

            builder.Property(x => x.SupplierId)
                   .IsRequired();

            builder.Property(x => x.StateId)
                   .IsRequired();

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.CategoryId);
            
            builder.HasOne(x => x.Supplier)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasMany(x => x.InventoryMovements)
                   .WithOne(x => x.Product)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); ;

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
