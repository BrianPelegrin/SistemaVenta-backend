using AutoMapper;
using MediatR;
using SistemaVenta.Application.Contracts.Persistence;

namespace SistemaVenta.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }
    }
}
