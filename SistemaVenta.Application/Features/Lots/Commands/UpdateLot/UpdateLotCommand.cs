using MediatR;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Commands.UpdateLot
{
    public class UpdateLotCommand : IRequest<LotDTO>
    {
        public UpdateLotDTO Lot { get; set; }
        public UpdateLotCommand(UpdateLotDTO lot)
        {
            Lot = lot;
        }
    }
}
