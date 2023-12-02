using Shipfinity.Domain.Models;

namespace Shipfinity.DTOs.CategoryDTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName {  get; set; }
    }
}
