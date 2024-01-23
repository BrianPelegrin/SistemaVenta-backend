using MediatR;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;

namespace SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliertById
{
    public class GetSupplierByIdQuery:IRequest<SupplierDTO>
    {
        public int Id { get; }
        public GetSupplierByIdQuery(int id)
        {
            Id = id;
        }
    }
}
