using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Product : BaseEntity
    {
        public Product()
        {
            InventoryMovements = new HashSet<InventoryMovement>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? BarCode { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Stock { get; set; }
        public int MinimalStock { get; set; }
        public string Image { get; set; } = string.Empty;

        public int? StorageId { get; set; }
        public int? SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
        public int? UnitMeasurementId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual State State { get; set; }   
        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
    }
}
