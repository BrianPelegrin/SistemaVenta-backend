using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class Lot:BaseEntity
    {
        public string LotNumber { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public string? BarCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? StorageId { get; set; }
        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual State State { get; set; }
        public Product Product { get; set; }

    }
}
