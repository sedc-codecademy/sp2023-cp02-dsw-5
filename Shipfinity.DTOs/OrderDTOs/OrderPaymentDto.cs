using Shipfinity.DTOs.PaymentInfoDTOs;

namespace Shipfinity.DTOs.OrderDTOs
{
    public class OrderPaymentDto:OrderCreateDto
    {
        public PaymentInfoDto PaymentInfo { get; set; }
    }
}
