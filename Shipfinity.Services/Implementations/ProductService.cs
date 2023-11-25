using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.DTOs.ProductDTO_s;
using Shipfinity.Mappers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductReadDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }

        public async Task<ProductReadDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new ProductNotFoundException(id);
            return ProductMapper.MapToReadDto(product);
        }

        public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto)
        {
            var newProduct = ProductMapper.MapToModel(productCreateDto);
            await _productRepository.InsertAsync(newProduct);
            return ProductMapper.MapToReadDto(newProduct);
        }

        public async Task UpdateProductAsync(int id, ProductUpdateDto productUpdateDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null) throw new ProductNotFoundException(id);

            ProductMapper.ApplyUpdateFromDto(existingProduct, productUpdateDto);
            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null) throw new ProductNotFoundException(id);

            await _productRepository.DeleteByIdAsync(id);
        }

        public async Task<List<ProductReadDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetAllByCategoryIdAsync(categoryId);
            if (!products.Any()) throw new CategoryNotFoundException(categoryId);

            return products.Select(ProductMapper.MapToReadDto).ToList();
        }

        public async Task<List<ProductReadDto>> GetProductsOnSaleAsync()
        {
         
            var products = (await _productRepository.GetAllAsync()).Where(p => p.DiscountPercenrage > 0).ToList();
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }

        public async Task<List<ProductReadDto>> GetProductsInRangeAsync(int skip, int take)
        {
            var products = await _productRepository.GetRangeAsync(skip, take);
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }
        public async Task UpdateProductPhotoUrl(int productId, string photoUrl)
        {
            await _productRepository.UpdateProductPhotoUrlAsync(productId, photoUrl);
        }
    }
}
