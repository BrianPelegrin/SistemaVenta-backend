using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;

namespace SistemaVenta.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, bool>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<bool> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var findedSupplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (findedSupplier == null)
            {
                throw new NotFoundException(string.Empty, request.Id);
            }

            await _supplierRepository.DeleteAsync(findedSupplier);

            return true;

        }
    }
}
