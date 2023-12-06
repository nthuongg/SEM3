using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Entities
{
    [Table("departments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name !")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public int NumberOfPersonals { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
