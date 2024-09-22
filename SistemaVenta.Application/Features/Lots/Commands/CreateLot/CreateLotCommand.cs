using MediatR;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Commands.CreateLot
{
    public class CreateLotCommand : IRequest<LotDTO>
    {
        public CreateLotDTO Lot { get; set; }
        public CreateLotCommand(CreateLotDTO lot)
        {   
            Lot = lot;
        }
    }
}
