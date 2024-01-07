using AutoMapper;
using SistemaVenta.Application.Features.Categories.Commands.CreateCategory;
using SistemaVenta.Domain.Entities.Inventory;

namespace SistemaVenta.Application.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCategoryCommand, Category>();
        }
    }

}
