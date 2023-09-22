using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipfinity.DTOs.ProductDTO_s;
using Shipfinity.Services.Interfaces;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly IProductService _productService;

    
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}
