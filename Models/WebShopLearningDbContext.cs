using Microsoft.EntityFrameworkCore;

namespace WebShopLearning.Models
{
    public class WebShopLearningDbContext : DbContext
    {
        public WebShopLearningDbContext(DbContextOptions<WebShopLearningDbContext> context) : base(context)
        {
        }

        // Register the classes
        public DbSet<User> User {  get; set; }
    }
}
