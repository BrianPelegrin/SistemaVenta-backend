﻿using MediatR;

namespace SistemaVenta.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Stock { get; set; }
        public int MinimalStock { get; set; }
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int StateId { get; set; }
        public int? UnitMeasurementId { get; set; }
    }
}
