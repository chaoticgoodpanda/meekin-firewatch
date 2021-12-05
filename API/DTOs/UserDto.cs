namespace API.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        // for the JWT
        public string Token { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public string Organization { get; set; }
    }
}