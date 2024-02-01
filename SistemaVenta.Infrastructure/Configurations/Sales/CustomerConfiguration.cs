using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Domain.Entities.Sales;
using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Infrastructure.Configurations.Sales
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(x => x.Invoices)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasData(

                    new Customer
                    {
                        Id = 1,
                        Name = "Pedro Navaja",
                        PhoneNumber = "200-000-0000",
                        Email = "pedrito@hotmail.com",
                        PersonType = PersonEnum.Customer,
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Juanito Alimaña",
                        PhoneNumber = "100-000-0000",
                        Email = "juanito.ali@gmail.com",
                        PersonType = PersonEnum.Customer,
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    }

                );
        }
    }
}
