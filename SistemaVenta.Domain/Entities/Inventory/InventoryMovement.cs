using SistemaVenta.Domain.Common;

namespace SistemaVenta.Domain.Entities.Inventory
{
    public class InventoryMovement : BaseEntity
    {
        public int MovementTypeId { get; set; }
        public int ProductId { get; set; }
        public int AffectedQuantity { get; set; }
        public int? OldValue { get; set; }
        public int? NewValue { get; set; }

        public virtual Product? Product { get; set; }
    }
}
