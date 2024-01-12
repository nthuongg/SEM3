using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string full_name { get; set; }
        [Required]
        [MinLength(6)]
        public string password { get; set; }

    }
}
