using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, UpdateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSupplierCommand> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var findedSupplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (findedSupplier == null)
            {
                throw new NotFoundException(request.Name,request.Id);
            }

            _mapper.Map(request,findedSupplier,typeof(UpdateSupplierCommand),typeof(Supplier));

            await _supplierRepository.UpdateAsync(findedSupplier);

            return request;
        }
    }
}
