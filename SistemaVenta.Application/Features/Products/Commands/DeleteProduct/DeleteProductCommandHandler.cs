using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;

namespace SistemaVenta.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var finded = await _productRepository.GetByIdAsync(request.Id);
            if (finded == null)
            {
                throw new NotFoundException("con el Id", request.Id);
            }

            await _productRepository.DeleteAsync(finded);

            return true;
        }
    }
}
