using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shipfinity.DTOs.CategoryDTOs;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");

            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound($"Category with Id {id} not found");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
                if (createCategoryDto == null || createCategoryDto.Name.IsNullOrEmpty())
                {
                    return BadRequest("Invalid input");
                }

                await _categoryService.CreateCategoryAsync(createCategoryDto);
                return StatusCode(StatusCodes.Status201Created, "Category created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                if (id != updateCategoryDto.Id)
                {
                    return BadRequest("Invalid Id");
                };

                await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
