using MediatR;

namespace SistemaVenta.Application.Features.Suppliers.Commands.CreateProvider
{
    public class CreateSupplierCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
