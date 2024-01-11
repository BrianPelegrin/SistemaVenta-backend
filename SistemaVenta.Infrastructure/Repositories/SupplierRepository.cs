using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Infrastructure.Persistence;

namespace SistemaVenta.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(InventoryDbContext dbContext) : base(dbContext) 
        {
            
        }
    }
}
