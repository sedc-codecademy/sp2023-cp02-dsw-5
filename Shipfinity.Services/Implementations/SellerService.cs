using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.DTOs.SellerDTO_s;
using Shipfinity.Services.Helpers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Services.Implementations
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task ResetPasswordAsync(SellerPasswordResetDto passwordResetDto)
        {
            if (passwordResetDto.NewPassword != passwordResetDto.ConfirmNewPassword)
                throw new BadRequestException("New password and confirmation do not match.");

            var seller = await _sellerRepository.GetByIdAsync(passwordResetDto.SellerId);
            if (seller == null)
                throw new SellerNotFoundException(passwordResetDto.SellerId);

            if (!seller.VerifyPassword(passwordResetDto.OldPassword))
                throw new BadRequestException("Old password is incorrect.");

            AuthHelper.HashPassword(passwordResetDto.NewPassword, out byte[] newHash, out byte[] newSalt);

            seller.PasswordHash = newHash;
            seller.PasswordSalt = newSalt;

            await _sellerRepository.UpdateAsync(seller);
        }
    }
}
