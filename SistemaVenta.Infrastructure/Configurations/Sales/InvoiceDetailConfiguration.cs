using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Sales;

namespace SistemaVenta.Infrastructure.Configurations.Sales
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoiceDetails");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ITBIS)
                .HasPrecision(18,2)
                .IsRequired();

            builder.Property(x=>x.UnitPrice)
                   .HasPrecision(18,2)
                   .IsRequired();

            builder.Property(x => x.ProductId)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.HasOne(x => x.Invoice)
                   .WithMany(x => x.InvoiceDetails)
                   .HasForeignKey(x => x.InvoiceId)
                   .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(x=>x.Producto)
                   .WithMany(x=>x.InvoiceDetails)
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
