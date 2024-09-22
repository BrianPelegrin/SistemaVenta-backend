using MediatR;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Queries.GetLotById
{
    public class GetLotByIdQuery : IRequest<LotDTO>
    {
        public int Id { get; set; }
        public GetLotByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
