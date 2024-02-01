using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Sales
{
    public class Customer : Person
    {
        public Customer()
        {
            this.PersonType = Enums.PersonEnum.Customer;            
        }

        public string? AccountState { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }

    }
}
