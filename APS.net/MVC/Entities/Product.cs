using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand? Brand { get; set; }

        public String Image { get; set; }

    }
}
