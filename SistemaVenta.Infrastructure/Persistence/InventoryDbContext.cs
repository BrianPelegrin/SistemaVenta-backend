using Microsoft.EntityFrameworkCore;
using SistemaVenta.Domain.Common;
using System.Reflection;

namespace SistemaVenta.Infrastructure.Persistence
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach(var entity in ChangeTracker.Entries<BaseEntity>())
            {

                switch(entity.State) 
                {
                    case EntityState.Added:
                        entity.Entity.CreatedAt = DateTime.Now;
                        entity.Entity.CreatedBy = "System";
                        break;

                    case EntityState.Modified:
                        entity.Entity.UpdatedAt = DateTime.Now;
                        entity.Entity.UpdatedBy = "System";
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
