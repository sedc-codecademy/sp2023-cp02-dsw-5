using Shipfinity.Domain.Models;
using Shipfinity.DTOs.CategoryDTOs;

namespace Shipfinity.Mappers
{
    public static class CategoryMappers
    {

        public static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                DisplayName = category.DisplayName,
            };
        }

        public static Category MapToCategory(CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                Name = createCategoryDto.Name,
                DisplayName = createCategoryDto.DisplayName,
            };
        }

        public static Category MapToCategory(this UpdateCategoryDto updateCategoryDto)
        {
            return new Category
            {
                Id = updateCategoryDto.Id,
                Name = updateCategoryDto.Name,
                DisplayName = updateCategoryDto.DisplayName,
            };
        }
    }
}
