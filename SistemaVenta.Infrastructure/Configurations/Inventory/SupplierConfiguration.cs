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

            builder.HasMany(x => x.Lots)
                   .WithOne(x => x.Supplier)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                    new Supplier
                    {
                        Id = 3,
                        Name = "Brugal",
                        PhoneNumber = "000-000-0000",
                        Email = "supplidor@brugal.com.do",
                        PersonType = PersonEnum.Supplier,
                        StateId = (int)ApplicationStates.Active,                        
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    },
                    new Supplier
                    {
                        Id= 4,
                        Name ="Induveca",
                        PhoneNumber = "000-000-0000",
                        Email = "supplidor@induveca.com.do",
                        PersonType = PersonEnum.Supplier,
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    }

                );
        }
    }
}
