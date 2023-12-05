using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class ReviewProduct : BaseEntity
    {
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
