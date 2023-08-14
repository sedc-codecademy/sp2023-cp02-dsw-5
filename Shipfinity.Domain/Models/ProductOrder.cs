using System.ComponentModel.DataAnnotations;

namespace Shipfinity.Domain.Models
{
    public class ProductOrder : BaseEntity
    {
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Range(0, 9999)]
        public int Quantity { get; set; }
    }
}
