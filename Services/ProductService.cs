using Microsoft.EntityFrameworkCore;
using WebShopLearning.Models;
using WebShopLearning.Interfaces;

namespace WebShopLearning.Services
{
    public class ProductService : IProductService
    {
        private readonly WebShopLearningDbContext _productPortalDbContext;
        public ProductService(WebShopLearningDbContext productPortalDbContext)
        {
            this._productPortalDbContext = productPortalDbContext;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _productPortalDbContext.Product.ToListAsync();
            return products;
        }
        
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productPortalDbContext.Product.FindAsync(id);
        }
        
        public async Task<Product> CreateProductAsync(Product product)
        {
            _productPortalDbContext.Product.Add(product);
            await _productPortalDbContext.SaveChangesAsync();
            return product;
        }
    }
}