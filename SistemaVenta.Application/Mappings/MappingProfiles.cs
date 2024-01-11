using AutoMapper;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Application.Features.Categories.Commands.UpdateCategory;
using SistemaVenta.Application.Features.Categories.Queries.GetCategoryList;
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

            CreateMap<Supplier,SuppliersDTO>();
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<UpdateSupplierCommand, Supplier>();
        }
    }

}
