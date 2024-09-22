using AutoMapper;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Application.Features.Categories.Commands.UpdateCategory;
using SistemaVenta.Application.Features.Categories.Queries.GetCategoryList;
using SistemaVenta.Application.Features.Lots.Commands.CreateLot;
using SistemaVenta.Application.Features.Lots.Queries.GetLotList;
using SistemaVenta.Application.Features.Products.Commands.CreateProduct;
using SistemaVenta.Application.Features.Products.Commands.UpdateProduct;
using SistemaVenta.Application.Features.Products.Queries.GetProductList;
using SistemaVenta.Application.Features.Suppliers.Commands.CreateProvider;
using SistemaVenta.Application.Features.Suppliers.Commands.UpdateSupplier;
using SistemaVenta.Application.Features.Suppliers.Queries.GetSuppliersList;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Supplier,SupplierDTO>();
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<UpdateSupplierCommand, Supplier>();

            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, ProductDTO>();
            
            CreateMap<Lot, LotDTO>().ReverseMap();
            CreateMap<Lot, UpdateLotDTO>().ReverseMap();
            CreateMap<Lot, CreateLotDTO>().ReverseMap();

        }
    }

}
