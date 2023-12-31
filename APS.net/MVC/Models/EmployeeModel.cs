﻿using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name !")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Rank { get; set; }        
        public int DepartmentId { get; internal set; }
    }
}
