using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exceptions;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using SistemaVenta.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Commands.CreateLot
{
    public class CreateLotCommandHandler : IRequestHandler<CreateLotCommand, LotDTO>
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public CreateLotCommandHandler(ILotRepository lotRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
        }

        public async Task<LotDTO> Handle(CreateLotCommand request, CancellationToken cancellationToken)
        {
            var exist = await _lotRepository.AnyAsync(x => x.LotNumber.Equals(request.Lot.LotNumber));

            if (exist)
            {
                throw new AlreadyExistException($"con el numero de lote ({request.Lot.LotNumber})");
            }

            var model = _mapper.Map<Lot>(request.Lot);
            model = await _lotRepository.AddAsync(model);

            return _mapper.Map<LotDTO>(model);
        }
    }
}
