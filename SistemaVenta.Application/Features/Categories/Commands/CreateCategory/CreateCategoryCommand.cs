using MediatR;
using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {        
        public string Name { get; set; } = string.Empty;
        public int StateId { get; set; } = (int)ApplicationStates.Active;
    }
}
