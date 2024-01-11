using MediatR;

namespace SistemaVenta.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteSupplierCommand(int id)
        {
            Id = id;
        }
    }
}
