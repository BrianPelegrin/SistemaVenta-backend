using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList
{
    public class GetSuppliersListQueryHandler : IRequestHandler<GetSuppliersListQuery, IEnumerable<SuppliersDTO>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public GetSuppliersListQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SuppliersDTO>> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var suppliersList = await _supplierRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<SuppliersDTO>>(suppliersList);
        }
    }
}
