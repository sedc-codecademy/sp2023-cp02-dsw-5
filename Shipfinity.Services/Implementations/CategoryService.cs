using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
using Shipfinity.Services.Interfaces;

namespace Shipfinity.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(string name)
        {
            name = name.Trim().Replace(' ', '_');
            Category category = new Category()
            {
                Name = name.ToLower(),
            };
            await _categoryRepository.InsertAsync(category);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
