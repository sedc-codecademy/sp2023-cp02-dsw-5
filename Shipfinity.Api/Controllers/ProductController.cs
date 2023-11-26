﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shipfinity.Domain.Models;
using Shipfinity.DTOs.ProductDTO_s;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly string _imagesPath;


        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _imagesPath = Path.Combine(env.WebRootPath, "images");
        }

        // HTTP GET to get all products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // HTTP GET to get a product by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // HTTP POST to create a new product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var product = await _productService.CreateProductAsync(productCreateDto);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // HTTP PUT to update an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            if (id <= 0 || !ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {
                await _productService.UpdateProductAsync(id, productUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // HTTP DELETE to delete a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid product ID");

            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ByCategory/{categoryId}")]
        private async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(categoryId);
                if (products == null || !products.Any())
                {
                    return NotFound("No products found for the given category.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("OnSale")]
        private async Task<IActionResult> GetProductsOnSale()
        {
            try
            {
                var products = await _productService.GetProductsOnSaleAsync();
                if (products == null || !products.Any())
                {
                    return NotFound("No products on sale.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Range/{skip}/{take}")]
        private async Task<IActionResult> GetProductsInRange(int skip, int take)
        {
            try
            {
                var products = await _productService.GetProductsInRangeAsync(skip, take);
                if (products == null || !products.Any())
                {
                    return NotFound("No products found in the given range.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{productId}/UploadPhoto")]
        public async Task<IActionResult> UploadPhoto(int productId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                // Ensure the images directory exists
                if (!Directory.Exists(_imagesPath))
                {
                    Directory.CreateDirectory(_imagesPath);
                }

                // Generate a unique file name to avoid overwriting existing files
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(_imagesPath, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Update product's photo URL in the database
                await _productService.UpdateProductPhotoUrl(productId, "/images/" + fileName);

                return Ok("File uploaded successfully.");
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest($"Product with id:{productId} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("{productId}/reviews")]
        public async Task<ActionResult<ReviewProduct>> CreateProductReview(int productId, ReviewProductDto productReviewDto)
        {
            try
            {
                var review = await _productService.CreateReviewProductAsync(productId, productReviewDto);
                return CreatedAtAction(nameof(CreateProductReview), new { productId = productId, id = review.Id }, review);
            }
            catch (ProductNotFoundException)
            {
                return NotFound($"Product with id {productId} not found.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"An error occurred while creating a review for product with id: {productId}", productId);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}