using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Vui long nhap ten")]
        [MinLength(6,ErrorMessage ="Ten danh muc toi thieu 6 ki tu")]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
