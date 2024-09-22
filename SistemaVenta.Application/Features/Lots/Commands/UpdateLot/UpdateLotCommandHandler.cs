using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using SistemaVenta.Application.Features.Suppliers.Commands.UpdateSupplier;
using SistemaVenta.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Commands.UpdateLot
{
    public class UpdateLotCommandHandler : IRequestHandler<UpdateLotCommand, LotDTO>
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public UpdateLotCommandHandler(ILotRepository lotRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
        }

        public async Task<LotDTO> Handle(UpdateLotCommand request, CancellationToken cancellationToken)
        {
            var findedLot = await _lotRepository.GetByIdAsync(request.Lot.Id);
            if (findedLot == null)
            {
                throw new NotFoundException(request.Lot.LotNumber, request.Lot.Id);
            }

            _mapper.Map(request.Lot, findedLot, typeof(UpdateLotDTO), typeof(Lot));

            await _lotRepository.UpdateAsync(findedLot);

            return _mapper.Map<LotDTO>(findedLot);
        }
    }
}
