using MediatR;

namespace SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList
{
    public class GetSuppliersListQuery : IRequest<IEnumerable<SupplierDTO>>
    {

    }
}
