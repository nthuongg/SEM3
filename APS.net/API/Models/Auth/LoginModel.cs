using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }
      
        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}
