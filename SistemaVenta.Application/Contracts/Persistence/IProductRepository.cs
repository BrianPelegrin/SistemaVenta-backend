using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
    }
}
