using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Domain.Entities.Inventory;
using SistemaVenta.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InventoryDbContext context): base(context)
        {
            
        }
    }
}
