using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Queries.GetLotList
{
    public class GetLotQueryHandler : IRequestHandler<GetLotQuery, IEnumerable<LotDTO>>
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public GetLotQueryHandler(ILotRepository lotRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LotDTO>> Handle(GetLotQuery request, CancellationToken cancellationToken)
        {
            var listIncludes = new List<Expression<Func<Lot, object>>>() 
            {
                x=>x.Supplier,
                x=>x.Product
            };
            
            var query = await _lotRepository.GetAllAsync(
                DisableTracking:true,
                IncludesProperties:listIncludes                
            );

            return _mapper.Map<IEnumerable<LotDTO>>(query);
        }
    }
}
