using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name !")]
        [MinLength(2, ErrorMessage = "Minimum 6 characters!")]
        public string Name { get; set; }    
        public double Price { get; set; }

        [MinLength(2, ErrorMessage = "Minimum 3 characters!")]
        public string Description { get; set; } 

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000!")]
        public int Quantity { get; set; }
        public IFormFile Image { get; set; }
    }
}
