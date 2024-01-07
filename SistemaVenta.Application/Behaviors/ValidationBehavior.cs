using FluentValidation;
using MediatR;
using ValidationException = SistemaVenta.Application.Exceptions.ValidationException;
namespace SistemaVenta.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validator.Select(VA => VA.ValidateAsync(context, cancellationToken)));

                var ValidationErrors = validationResults.SelectMany(VR => VR.Errors).Where(ER => ER != null);

                if (ValidationErrors.Count() != 0)
                {
                    throw new ValidationException(ValidationErrors);
                }
            }

            return await next();
        }
    }
}
