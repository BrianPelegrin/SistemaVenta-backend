using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Sales
{
    public class Invoice : BaseEntity
    {

        public string? InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Note { get; set; }

        public Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail>? InvoiceDetails { get; set; } 
    }
}
