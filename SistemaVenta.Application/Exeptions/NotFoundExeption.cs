namespace SistemaVenta.Application.Exeptions
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string name, object key): base($"El registro {name} ({key}) no fue encontrado")
        {
            
        }
    }
}
