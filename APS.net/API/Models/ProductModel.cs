using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public string? thumbnail { get; set; }
        [Required]

        public decimal price { get; set; }
        [Required]

        public int qty { get; set; }

        public string? description { get; set; }


    }
}
