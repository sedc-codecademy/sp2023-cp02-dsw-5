using Shipfinity.Domain.Models;

namespace Shipfinity.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
    }
}
