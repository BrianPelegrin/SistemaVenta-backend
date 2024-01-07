namespace SistemaVenta.Application.Features.Categories.Queries.GetCategoryList
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StateId { get; set; }
    }
}