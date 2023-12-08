using Shipfinity.DTOs.SellerDTO_s;

namespace Shipfinity.Services.Interfaces
{
    public interface ISellerService
    {
        Task ResetPasswordAsync(SellerPasswordResetDto passwordResetDto);
    }
}
