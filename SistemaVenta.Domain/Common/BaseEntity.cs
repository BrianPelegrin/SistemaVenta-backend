namespace SistemaVenta.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
