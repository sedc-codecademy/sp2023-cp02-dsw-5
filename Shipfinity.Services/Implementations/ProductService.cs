﻿using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Domain.Models;
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

        public async Task<ProductDetailsDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new ProductNotFoundException(id);
            return ProductMapper.MapToDetailsDto(product);
        }

        public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto productCreateDto, int sellerId)
        {
            var newProduct = ProductMapper.MapToModel(productCreateDto);
            newProduct.SellerId = sellerId;
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
            var products = await _productRepository.GetProductsOnSaleAsync();
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }

        public async Task<ProductPaginatedResponse> GetProductsInRangeAsync(int skip, int take)
        {
            var products = await _productRepository.GetRangeAsync(skip, take);
            ProductPaginatedResponse response = new ProductPaginatedResponse();
            response.Count = await _productRepository.GetCount();
            response.Products = products.Select(ProductMapper.MapToReadDto).ToList();
            return response;
        }
        public async Task UpdateProductPhotoUrl(int productId, string photoUrl)
        {
            await _productRepository.UpdateProductPhotoUrlAsync(productId, photoUrl);
        }

        public async Task<List<ProductReadDto>> SearchProductsByKeywordAsync(string keyword)
        {
            var products = await _productRepository.SearchProductsAsync(keyword);
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }

        public async Task<ReviewProductReadDto> CreateReviewProductAsync(int productId, ReviewProductDto reviewProductDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new ProductNotFoundException(productId);

            var newReview = new ReviewProduct
            {
                Comment = reviewProductDto.Comment,
                Rating = reviewProductDto.Rating,
                ProductId = productId,
                CustomerId = reviewProductDto.CustomerId
            };

            await _productRepository.AddProductReviewAsync(newReview);

            var productReviews = await _productRepository.GetProductReviewsByProductIdAsync(productId);

            int totalRatings = productReviews.Count();
            int sumOfRatings = productReviews.Sum(r => r.Rating);

            double averageRating = totalRatings > 0 ? (double)sumOfRatings / totalRatings : 0;

            product.Rating = (short)Math.Round(averageRating, MidpointRounding.AwayFromZero);
            await _productRepository.UpdateAsync(product);

            return ProductMapper.MapToReadDto(newReview);
        }

        public async Task<ProductPaginatedResponse> GetProductsByCategoryPaginated(int categoryId, int skip, int take)
        {
            ProductPaginatedResponse response = new ProductPaginatedResponse();
            response.Count = await _productRepository.GetCount(categoryId);
            var products = await _productRepository.GetRangeByCategoryId(categoryId, skip, take);
            response.Products = products.Select(ProductMapper.MapToReadDto).ToList();
            return response;
        }

        public async Task<List<ProductReadDto>> GetProductsBySellerIdAsync(int sellerId)
        {
            var products = await _productRepository.GetProductsBySellerIdAsync(sellerId);
            return products.Select(ProductMapper.MapToReadDto).ToList();
        }
    }
}
