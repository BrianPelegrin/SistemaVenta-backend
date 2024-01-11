using FluentValidation;

namespace SistemaVenta.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El Id no puede ser nulo")
                .NotEqual(0).WithMessage("El Id no puede ser 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .NotNull().WithMessage("El nombre no puede ser nulo")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracters");
        }
    }
}
