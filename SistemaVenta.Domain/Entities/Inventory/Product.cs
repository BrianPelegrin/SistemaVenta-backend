using SistemaVenta.Domain.Common;
using SistemaVenta.Domain.Entities.Sales;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Product : BaseEntity
    {
        public Product()
        {
            InventoryMovements = new HashSet<InventoryMovement>();
            InvoiceDetails = new HashSet<InvoiceDetail>();
            Lots = new HashSet<Lot>();
        }
        public string? BarCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Stock { get; set; }
        public decimal MinimalStock { get; set; }
        public string Image { get; set; } = string.Empty;              
        public int CategoryId { get; set; }
        public int? UnitMeasurementId { get; set; }

        public virtual Category Category { get; set; }        
        public virtual State State { get; set; }
        public virtual ICollection<Lot>? Lots { get; set; }
        public virtual ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
        public virtual ICollection<InventoryMovement>? InventoryMovements { get; set; }
    }
}
