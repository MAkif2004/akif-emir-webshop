using Microsoft.AspNetCore.Mvc;
using WebShopLearning.Interfaces;
using WebShopLearning.Models;

namespace WebShopLearning.Controllers
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
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            
            product.UserId = int.Parse(userId);
            
            var created = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = created.Id }, created);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _productService.GetAllProductsAsync();

            return Ok(product);
        }
    }
}