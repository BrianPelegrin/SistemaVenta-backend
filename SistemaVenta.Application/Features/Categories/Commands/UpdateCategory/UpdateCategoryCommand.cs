using MediatR;

namespace SistemaVenta.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StateId { get; set; }
    }
}
