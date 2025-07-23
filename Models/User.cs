using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopLearning.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string first_name { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string last_name { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string password { get; set; } = "";

        public string? number { get; set; }
    }
}
