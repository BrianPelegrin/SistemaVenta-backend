using FluentValidation;

namespace SistemaVenta.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(2);

            RuleFor(p => p.BarCode)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.SalePrice)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.PurchasePrice)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.CategoryId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.StateId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty();
        }
    }
}
