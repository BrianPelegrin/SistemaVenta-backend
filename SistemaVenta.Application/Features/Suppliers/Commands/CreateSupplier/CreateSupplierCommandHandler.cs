using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exceptions;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Features.Suppliers.Commands.CreateProvider
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            bool exist = await _supplierRepository.AnyAsync(s => s.Name.Equals(request.Name) ||                                                                 
                                                                 s.Email.Equals(request.Email));

            if (exist)
            {
                throw new AlreadyExistException($"{request.Name} o {request.Email}");
            }

            var newSupplier = _mapper.Map<Supplier>(request);

            var savedSupplier = await _supplierRepository.AddAsync(newSupplier);

            return newSupplier.Id;
       
        }
    }
}
