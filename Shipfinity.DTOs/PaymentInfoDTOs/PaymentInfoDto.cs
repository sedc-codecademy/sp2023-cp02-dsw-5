namespace Shipfinity.DTOs.PaymentInfoDTOs
{
    public class PaymentInfoDto
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; } 
        public int CVV {  get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
    }
}
