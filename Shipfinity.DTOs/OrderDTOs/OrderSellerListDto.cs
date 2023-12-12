using Shipfinity.Domain.Enums;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderSellerListDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public string Address { get; set; }
    }
}
