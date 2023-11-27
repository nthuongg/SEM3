namespace MVC.Models
{
    public class UserRegisterModel
    {
        //private string email; // attribute

        public int Id { get; set; }  // abstract property
        public string Email { get; set; } 
        public string FullName { get; set; }    
        public string Telephone { get; set; }        
    }
}
