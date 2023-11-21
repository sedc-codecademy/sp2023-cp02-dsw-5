using System.ComponentModel.DataAnnotations;

namespace Shipfinity.DTOs.UserDTOs
{
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
