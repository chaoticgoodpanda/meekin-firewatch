using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,]).*$", ErrorMessage = "Password must " +
            "contain at least one lowercase letter, one uppercase letter, one number and one special character.")]
        public string Password { get; set; }
        public string Username { get; set; }
        public string Organization { get; set; }
    }
}