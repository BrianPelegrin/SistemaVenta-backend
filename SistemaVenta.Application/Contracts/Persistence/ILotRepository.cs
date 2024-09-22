using SistemaVenta.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Contracts.Persistence
{
    public interface ILotRepository: IAsyncRepository<Lot>
    {

    }
}
