using Shipfinity.Domain.Models;

namespace Shipfinity.DTOs.CategoryDTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; }
    }
}
