using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliertById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDTO>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async  Task<SupplierDTO> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var findedSupplier = await _supplierRepository.GetByIdAsync(request.Id);
            
            if( findedSupplier == null )
            {
                throw new NotFoundException("con el id",request.Id);
            }

            return _mapper.Map<SupplierDTO>(findedSupplier);
        }
    }
}
