using MediatR;

namespace SistemaVenta.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public DeleteCategoryCommand(int id) 
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
