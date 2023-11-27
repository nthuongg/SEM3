using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CategoryModel
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
