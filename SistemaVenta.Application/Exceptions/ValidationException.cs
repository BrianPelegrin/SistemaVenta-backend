using FluentValidation.Results;

namespace SistemaVenta.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException():base("Hay uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> validationErrors):this()
        {
            Errors = validationErrors.GroupBy(E => E.PropertyName, E => E.ErrorMessage)
                                     .ToDictionary(E => E.Key, E => E.ToArray());
        }
    }
}
