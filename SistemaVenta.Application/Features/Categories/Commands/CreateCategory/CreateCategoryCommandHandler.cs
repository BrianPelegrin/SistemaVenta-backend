using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;
using SistemaVenta.Application.Exceptions;
using SistemaVenta.Domain.Entities.Inventory;
namespace SistemaVenta.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var exist = await _categoryRepository.AnyAsync(x => x.Name.Equals(request.Name));
            if (exist)
            {
                throw new AlreadyExistException(request.Name);
            }

            var categoryToAdd = _mapper.Map<Category>(request);

            var SavedCategory = await _categoryRepository.AddAsync(categoryToAdd);

            return SavedCategory.Id;

        }
    }
}
