using Microsoft.EntityFrameworkCore;
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
    public class LotRepository : BaseRepository<Lot>, ILotRepository
    {
        public LotRepository(InventoryDbContext context): base(context)
        {
            
        }
    }
}
