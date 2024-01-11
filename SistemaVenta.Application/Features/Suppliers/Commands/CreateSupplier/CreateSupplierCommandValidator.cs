using FluentValidation;

namespace SistemaVenta.Application.Features.Suppliers.Commands.CreateProvider
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotNull().WithMessage("El nombre no puede ser nulo")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracters");
            
        }
    }
}
