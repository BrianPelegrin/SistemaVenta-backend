using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;

namespace SistemaVenta.Application.Features.Lots.Queries.GetLotById
{
    public class GetLotByIdQueryHandler : IRequestHandler<GetLotByIdQuery, LotDTO>
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public GetLotByIdQueryHandler(ILotRepository lotRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
        }

        public async Task<LotDTO> Handle(GetLotByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _lotRepository.GetByIdAsync(request.Id);

            if (result == null)
            {
                throw new NotFoundException("con el id", request.Id);
            }

            return _mapper.Map<LotDTO>(result);
        }
    }
}
