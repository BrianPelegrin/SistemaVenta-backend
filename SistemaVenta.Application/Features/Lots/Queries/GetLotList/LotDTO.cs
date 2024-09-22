using SistemaVenta.Application.Features.Products.Queries.GetProductList;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;
using SistemaVenta.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Features.Lots.Queries.GetLotList
{
    public class LotDTO
    {
        public int Id { get; set; }
        public string LotNumber { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public int? StorageId { get; set; }
        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
        public SupplierDTO Supplier { get; set; } = new SupplierDTO();
        public ProductDTO Product { get; set; } = new ProductDTO();
    }

    public class CreateLotDTO
    {
        public string LotNumber { get; set; } = string.Empty;
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public int? StorageId { get; set; }
        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
    }

    public class UpdateLotDTO : CreateLotDTO
    {
        public int Id { get; set; }
    }
}
