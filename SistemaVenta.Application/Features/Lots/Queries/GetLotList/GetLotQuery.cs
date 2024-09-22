using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Queries.GetLotList
{
    public class GetLotQuery: IRequest<IEnumerable<LotDTO>>
    {
        public GetLotQuery() 
        {
            
        }
    }
}
