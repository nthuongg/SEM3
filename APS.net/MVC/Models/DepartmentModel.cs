using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name !")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public int NumberOfPersonals { get; set; }

        public List<EmployeeModel> Employees { get; set; }
    }
}
