namespace SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int StateId { get; set; }
    }
}
