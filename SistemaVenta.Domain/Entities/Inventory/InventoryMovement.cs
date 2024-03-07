using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class InventoryMovement : BaseEntity
    {
        public int MovementTypeId { get; set; }
        public int ProductId { get; set; }
        public decimal AffectedQuantity { get; set; }
        public decimal? OldValue { get; set; }
        public decimal? NewValue { get; set; }

        public virtual Product? Product { get; set; }
    }
}
