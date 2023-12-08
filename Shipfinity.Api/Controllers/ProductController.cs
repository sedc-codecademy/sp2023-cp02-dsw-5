using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shipfinity.Domain.Enums;
using Shipfinity.DTOs.ProductDTO_s;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;
using System.Security.Claims;
using Shipfinity.Api.Helpers;

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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [CustomRoles(Roles.Seller, Roles.Admin)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue("id"));
                var product = await _productService.CreateProductAsync(productCreateDto, userId);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // HTTP PUT to update an existing product
        [HttpPut("{id}")]
        [CustomRoles(Roles.Seller, Roles.Admin)]
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
        [CustomRoles(Roles.Admin)]
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
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsByCategory(int categoryId, [FromQuery] int? skip, [FromQuery] int? take)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("OnSale")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsOnSale()
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

        [HttpGet("Range")]
        [AllowAnonymous]
        private async Task<IActionResult> GetProductsInRange([FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var products = await _productService.GetProductsInRangeAsync(skip, take);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{productId}/UploadPhoto")]
        [CustomRoles(Roles.Seller, Roles.Admin)]
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
                string photoUrl = $"{Request.Scheme}://{Request.Host.Value}/images/{fileName}";
                await _productService.UpdateProductPhotoUrl(productId, photoUrl);

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

        [HttpGet("search/{keyword}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProductReadDto>>> SearchProductsByKeyword(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return BadRequest("Keyword cannot be null or whitespace.");
                }

                var products = await _productService.SearchProductsByKeywordAsync(keyword);

                if (products == null || !products.Any())
                {
                    return NotFound($"No products found with keyword: {keyword}");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost("{productId}/reviews")]
        [Authorize]
        public async Task<IActionResult> AddProductReview(int productId, [FromBody] ReviewProductDto reviewProductDto)
        {
            if (productId <= 0 || !ModelState.IsValid)
                return BadRequest("Invalid input");

            try
            {
                var reviewProduct = await _productService.CreateReviewProductAsync(productId, reviewProductDto);
                return CreatedAtAction(nameof(GetProductById), new { id = productId }, reviewProduct);
            }
            catch (ProductNotFoundException ex)
            {
                Log.Error(ex.Message);
                return NotFound($"Product with id:{productId} not found.");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, $"An error occurred while creating a review for product with id: {productId}", productId);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("seller/{sellerId}")]
        public async Task<IActionResult> GetProductsBySellerId(int sellerId)
        {
            if (sellerId <= 0 || !ModelState.IsValid)
            {
                return BadRequest("Invalid seller ID");
            }

            try
            {
                var products = await _productService.GetProductsBySellerIdAsync(sellerId);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}