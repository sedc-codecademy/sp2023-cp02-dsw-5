namespace Shipfinity.Domain.Models
{
    public class PaymentInfo: BaseEntity
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public List<Order> Orders { get; set; } = new();
        public Customer? Customer { get; set; } = new();
        public int? CustomerId { get; set; } 
    }
}
