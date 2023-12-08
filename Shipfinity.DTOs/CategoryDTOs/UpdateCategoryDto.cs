namespace Shipfinity.DTOs.CategoryDTOs
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; }
    }
}
