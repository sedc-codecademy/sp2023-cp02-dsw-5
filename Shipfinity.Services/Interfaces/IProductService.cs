using Shipfinity.Domain.Models;
using Shipfinity.DTOs.ProductDTO_s;

namespace Shipfinity.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductReadDto>> GetAllProductsAsync();
        Task<ProductReadDto> GetProductByIdAsync(int id);
        Task<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto);
        Task UpdateProductAsync(int id, ProductUpdateDto productUpdateDto);
        Task DeleteProductAsync(int id);
        Task<List<ProductReadDto>> GetProductsByCategoryAsync(int categoryId);
        Task<List<ProductReadDto>> GetProductsOnSaleAsync();
        Task<List<ProductReadDto>> GetProductsInRangeAsync(int skip, int take);
        Task UpdateProductPhotoUrl(int productId, string photoUrl);



    }
}
