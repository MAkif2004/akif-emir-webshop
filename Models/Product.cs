using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopLearning.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; } // Uncomment if you have a User entity
    }
}
