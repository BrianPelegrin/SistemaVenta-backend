using MediatR;

namespace SistemaVenta.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string? BarCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;       
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Stock { get; set; }
        public decimal MinimalStock { get; set; }
        public string Image { get; set; } = string.Empty;        
        public int CategoryId { get; set; }
        public int StateId { get; set; }
        public int? UnitMeasurementId { get; set; }
    }
}
