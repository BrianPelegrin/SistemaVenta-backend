using SistemaVenta.Domain.Common;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Domain.Entities.Sales
{
    public class InvoiceDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ITBIS { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }

        public Product Producto { get; set; }
        public Invoice Invoice { get; set; }

    }
}
