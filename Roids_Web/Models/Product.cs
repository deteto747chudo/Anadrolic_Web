using System.ComponentModel.DataAnnotations;

namespace Roids_Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
