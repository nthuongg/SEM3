namespace API.DTOs
{
    public class UserDTO
    {
        public int id { get; set; }

        public string full_name { get; set; } = null!;

        public string email { get; set; } = null!;

        public string token { get; set; }
    }
}
