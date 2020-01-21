using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "You must provide a password between {2} and {1} characters")]
        public string Password { get; set; }
    }
}