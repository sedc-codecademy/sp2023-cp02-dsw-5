using Shipfinity.Domain.Models;
using Shipfinity.DTOs.ProductDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ImageUrl = product.ImageUrl
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
                ImageUrl = productCreateDto.ImageUrl
            };
        }

        public static void ApplyUpdateFromDto(Product product, ProductUpdateDto productUpdateDto)
        {
            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.Price = productUpdateDto.Price;
            product.CategoryId = productUpdateDto.CategoryId;
            product.ImageUrl = productUpdateDto.ImageUrl;
        }
    }
}

