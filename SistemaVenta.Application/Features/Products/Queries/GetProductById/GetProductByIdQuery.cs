using MediatR;
using SistemaVenta.Application.Features.Products.Queries.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ProductDTO>
    {
        public int ProductId { get; set; }
        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
