using MediatR;

namespace SistemaVenta.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<CategoryDTO>>
    {
        public Task<IEnumerable<CategoryDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
