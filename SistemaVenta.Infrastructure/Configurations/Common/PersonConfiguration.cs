using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Common;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Domain.Entities.Sales;
using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Infrastructure.Configurations.Common
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.ToTable("Persons");

            builder.HasDiscriminator<PersonEnum>(x => x.PersonType)
                   .HasValue<Person>(PersonEnum.Person)
                   .HasValue<Supplier>(PersonEnum.Supplier)
                   .HasValue<Customer>(PersonEnum.Customer);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired(false)
                   .HasMaxLength(50);

            builder.Property(x => x.Email)
                   .IsRequired(false)
                   .HasMaxLength(50);

            builder.Property(x => x.Address)
                   .IsRequired(false)
                   .HasMaxLength(200);

            builder.Property(x => x.Note)
                   .IsRequired(false)
                   .HasMaxLength(200);

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
