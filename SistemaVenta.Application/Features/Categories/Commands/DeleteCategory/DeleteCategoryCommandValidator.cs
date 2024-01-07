using FluentValidation;

namespace SistemaVenta.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x=>x.Id)
                .NotNull().WithMessage("El Id no puede estar nulo");
        }
    }
}
