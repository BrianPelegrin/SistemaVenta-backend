using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exeptions;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            
            var FindedCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (FindedCategory == null)
            {
                throw new NotFoundException(request.Name,request.Id);
            }

            _mapper.Map(request,FindedCategory,typeof(UpdateCategoryCommand),typeof(Category));

            await _categoryRepository.UpdateAsync(FindedCategory);
            
            return Unit.Value;
        }
    }
}
