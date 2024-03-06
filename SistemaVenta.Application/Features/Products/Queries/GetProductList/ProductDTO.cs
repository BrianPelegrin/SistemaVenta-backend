using SistemaVenta.Application.Features.Categories.Queries.GetCategoryList;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;

namespace SistemaVenta.Application.Features.Products.Queries.GetProductList
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? BarCode { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Stock { get; set; }
        public int MinimalStock { get; set; }
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int? UnitMeasurementId { get; set; }

        public virtual CategoryDTO? Category { get; set; }
        //public virtual StateDTO State { get; set; }
    }
}
