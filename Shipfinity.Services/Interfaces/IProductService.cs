using Shipfinity.Domain.Models;
using Shipfinity.DTOs.ProductDTO_s;

namespace Shipfinity.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductReadDto>> GetAllProductsAsync();
        Task<ProductDetailsDto> GetProductByIdAsync(int id);
        Task<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto, int sellerId);
        Task UpdateProductAsync(int id, ProductUpdateDto productUpdateDto);
        Task DeleteProductAsync(int id);
        Task<List<ProductReadDto>> GetProductsByCategoryAsync(int categoryId);
        Task<List<ProductReadDto>> GetProductsOnSaleAsync();
        Task<ProductPaginatedResponse> GetProductsInRangeAsync(int skip, int take);
        Task<ProductPaginatedResponse> GetProductsByCategoryPaginated(int categoryId, int skip, int take);
        Task UpdateProductPhotoUrl(int productId, string photoUrl);
        Task<List<ProductReadDto>> SearchProductsByKeywordAsync(string keyword);
        Task<ReviewProductReadDto> CreateReviewProductAsync(int productId, ReviewProductDto reviewProductDto);
        Task<List<ProductReadDto>> GetProductsBySellerIdAsync(int sellerId);
    }
}
