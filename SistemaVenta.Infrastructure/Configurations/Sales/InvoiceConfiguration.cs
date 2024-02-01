using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Sales;

namespace SistemaVenta.Infrastructure.Configurations.Sales
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DueDate);

            builder.Property(x => x.CustomerId)
                   .IsRequired();

            builder.Property(x => x.Note)
                   .IsRequired(false)
                   .HasMaxLength(200);

            builder.HasOne(x=>x.Customer)
                   .WithMany(x=>x.Invoices)
                   .HasForeignKey(x=>x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.InvoiceDetails)
                   .WithOne(x => x.Invoice)
                   .HasForeignKey(x => x.InvoiceId)
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
