using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC.Entities
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required] //not null
        public string Name { get; set; }

    }
}
