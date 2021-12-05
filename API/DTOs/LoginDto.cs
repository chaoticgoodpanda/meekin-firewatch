namespace API.DTOs
{
    public class LoginDto
    {
        // so logins can either be username OR email, like many apps offer
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}