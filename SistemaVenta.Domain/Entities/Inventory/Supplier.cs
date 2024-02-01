using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Supplier : Person
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            this.PersonType = Enums.PersonEnum.Supplier;
        }        

        public virtual ICollection<Product> Products { get; set; }
    }
}
