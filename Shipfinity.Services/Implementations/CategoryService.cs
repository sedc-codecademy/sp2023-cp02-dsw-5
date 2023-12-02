using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.CategoryDTOs;
using Shipfinity.Mappers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = CategoryMappers.MapToCategory(createCategoryDto);
            await _categoryRepository.InsertAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
           await _categoryRepository.DeleteByIdAsync(id);
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(CategoryMappers.MapToDto).ToList();

        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null ? CategoryMappers.MapToDto(category) : null;
        }

        public async Task UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(updateCategoryDto.Id);
            if (existingCategory != null)
            {

                existingCategory = updateCategoryDto.MapToCategory();
                await _categoryRepository.UpdateAsync(existingCategory);
            }
            else
            {
                throw new CategoryNotFoundException(updateCategoryDto.Id);
            }
        }
    }
}
