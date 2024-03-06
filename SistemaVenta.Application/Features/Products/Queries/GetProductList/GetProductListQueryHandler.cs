using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Domain.Entities.Inventory;
using System.Linq.Expressions;

namespace SistemaVenta.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Product, object>>> IncludesProperties = new List<Expression<Func<Product, object>>>
            {
                
            };

            var productsList = await _productRepository.GetAllAsync(IncludesProperties: new List<Expression<Func<Product, object>>>
                                                                    {
                                                                        x=>x.Category,
                                                                    });
            

            return _mapper.Map<IEnumerable<ProductDTO>>(productsList);
        }
    }
}
