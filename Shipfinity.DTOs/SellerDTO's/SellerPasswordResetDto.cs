namespace Shipfinity.DTOs.SellerDTO_s
{
    public class SellerPasswordResetDto
    {
        public int SellerId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
