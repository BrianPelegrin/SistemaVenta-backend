using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exceptions;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            bool exist = await _productRepository.AnyAsync(P=> P.Name.Equals(request.Name));

            if (exist)
            {
                throw new AlreadyExistException(request.Name);
            }

            var newProduct = _mapper.Map<Product>(request);
            
            await _productRepository.AddAsync(newProduct);

            return newProduct.Id;
        }
    }
}
