using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return new JsonResult(await _productService.GetAllAsync());
        }
    }
}
