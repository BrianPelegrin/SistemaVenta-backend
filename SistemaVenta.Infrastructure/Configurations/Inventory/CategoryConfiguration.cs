using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Infrastructure.Configurations.Inventory
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId);

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

                    new Category
                    {
                        Id = 1,
                        Name = "Bebidas Alcoholicas",
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Embutidos",
                        StateId = (int)ApplicationStates.Active,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Admin",
                    }

                );
        }
    }
}
