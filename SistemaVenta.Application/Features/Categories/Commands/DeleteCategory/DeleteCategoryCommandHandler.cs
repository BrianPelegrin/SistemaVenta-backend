using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;

namespace SistemaVenta.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var FindedCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (FindedCategory == null)
            {
                throw new NotFoundException("Buscado", request.Id);
            }

            await _categoryRepository.DeleteAsync(FindedCategory);

            return true;

        }
    }
}
