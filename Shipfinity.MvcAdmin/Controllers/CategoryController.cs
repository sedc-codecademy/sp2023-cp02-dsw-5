using Microsoft.AspNetCore.Mvc;
using Shipfinity.Domain.Models;
using Shipfinity.Services.Interfaces;
using Shipfinity.ViewModels.CategoryViewModels;

namespace Shipfinity.MvcAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel? category) {
            if(category == null)
            {
                TempData["Error"] = "Category not provided";
                return RedirectToAction("Index");
            }

            await _categoryService.CreateAsync(category.Name);
            TempData["Success"] = "Category created";
            return RedirectToAction("Index");
        }
    }
}
