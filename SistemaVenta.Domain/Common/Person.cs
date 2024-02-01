using SistemaVenta.Domain.Enums;

namespace SistemaVenta.Domain.Common
{
    public class Person : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public PersonEnum PersonType { get; set; } 
    }
}
