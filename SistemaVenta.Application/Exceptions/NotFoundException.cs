namespace SistemaVenta.Application.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key): base($"El registro {name} ({key}) no fue encontrado")
        {
            
        }
    }
}
