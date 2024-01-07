using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Infrastructure.Configurations.Inventory
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Email)
                   .IsRequired(false)
                   .HasMaxLength(50);

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

            builder.HasData(

                    new Supplier
                    {
                        Id = 1,
                        Name = "Brugal",
                        PhoneNumber = "000-000-0000",
                        StateId = (int)ApplicationStates.Active,                        
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    },
                    new Supplier
                    {
                        Id= 2,
                        Name ="Induveca",
                        PhoneNumber = "000-000-0000",
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    }

                );
        }
    }
}
