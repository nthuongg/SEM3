using MVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Entities
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Rank { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
