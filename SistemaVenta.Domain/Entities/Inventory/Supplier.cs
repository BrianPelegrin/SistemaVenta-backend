using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Supplier : Person
    {
        public Supplier()
        {
            Lots = new HashSet<Lot>();
            this.PersonType = Enums.PersonEnum.Supplier;
        }        

        public virtual ICollection<Lot> Lots { get; set; }
    }
}
