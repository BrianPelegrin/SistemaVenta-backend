using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {        
    }
}
