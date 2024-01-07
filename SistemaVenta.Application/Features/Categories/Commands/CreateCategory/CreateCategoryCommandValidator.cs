using FluentValidation;

namespace SistemaVenta.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre de la categoria no puede estar vacio")
                .NotNull().WithMessage("El Nombre de la categoria no puede ser nulo");
        }
    }
}
