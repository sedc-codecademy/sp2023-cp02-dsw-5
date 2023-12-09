using Shipfinity.DTOs.CategoryDTOs;

namespace Shipfinity.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
