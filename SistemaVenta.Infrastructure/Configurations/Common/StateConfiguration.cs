using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Common;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Infrastructure.Configurations.Common
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Ignore(x => x.StateId);

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

            //SEED DATA

            builder.HasData(

                    new State
                    {
                        Id = 1,
                        Name = "Activo",
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin"
                    },
                    new State
                    {
                        Id = 2,
                        Name = "Inactivo",
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin"
                    },
                    new State
                    {
                        Id = 3,
                        Name = "Agotado",
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin"
                    }

                );
        }
    }
}
