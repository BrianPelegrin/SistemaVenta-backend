using MediatR;

namespace SistemaVenta.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
