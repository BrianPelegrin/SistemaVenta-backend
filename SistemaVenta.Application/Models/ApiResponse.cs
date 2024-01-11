namespace SistemaVenta.Application.Models
{
    public class ApiResponse
    {
        public ApiResponse(string message, object? data = null)
        {
            Message = message;
            Data = data;
        }
        public string Message { get;  } = string.Empty;
        public object? Data { get; } = string.Empty;

    }

    public class ApiResponse<T>
    {
        public ApiResponse(string message, T? data = default(T))
        {
            Message = message;
            Data = data;
        }
        public string Message { get; } = string.Empty;
        public T? Data { get; } = default(T);

    }
}
