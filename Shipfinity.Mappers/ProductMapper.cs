using Shipfinity.Domain.Models;
using Shipfinity.DTOs.ProductDTO_s;

namespace Shipfinity.Mappers
{
    public static class ProductMapper
    {
        public static ProductReadDto MapToReadDto(Product product)
        {
            return new ProductReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                Rating = product.Rating

            };
        }

        public static Product MapToModel(ProductCreateDto productCreateDto)
        {
            return new Product
            {
                Name = productCreateDto.Name,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price,
                CategoryId = productCreateDto.CategoryId,
                DiscountPercenrage = 0,
                Rating = 0,
                ImageUrl = null
            };
        }

        public static void ApplyUpdateFromDto(Product product, ProductUpdateDto productUpdateDto)
        {
            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.Price = productUpdateDto.Price;
            product.CategoryId = productUpdateDto.CategoryId;
            product.DiscountPercenrage = productUpdateDto.DiscountPercentage;
        }

        public static ReviewProductReadDto MapToReadDto(ReviewProduct reviewProduct)
        {
            return new ReviewProductReadDto
            {
                Comment = reviewProduct.Comment,
                Rating = reviewProduct.Rating,
                ProductId = reviewProduct.ProductId,
                CustomerId = reviewProduct.CustomerId
            };
        }

        public static ProductDetailsDto MapToDetailsDto(Product product)
        {
            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                Rating = product.ProductReviews.Any() ? product.ProductReviews.Average(r => r.Rating) : 0

            };
        }
    }
}

