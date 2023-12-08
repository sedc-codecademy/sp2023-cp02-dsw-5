using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class Message : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        public string Role { get; set; }
    }
}
