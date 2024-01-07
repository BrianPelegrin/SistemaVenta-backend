using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }      

        public virtual ICollection<Product> Products { get; set; }
    }
}
