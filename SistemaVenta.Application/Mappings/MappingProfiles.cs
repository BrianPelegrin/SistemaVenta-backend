using AutoMapper;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Application.Features.Categories.Commands.UpdateCategory;
using SistemaVenta.Application.Features.Categories.Queries.GetCategoryList;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }

}
