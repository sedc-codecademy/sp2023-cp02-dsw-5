using Shipfinity.Domain.Models;

namespace Shipfinity.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task CreateAsync(string name);
    }
}
