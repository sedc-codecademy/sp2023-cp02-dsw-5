using Shipfinity.DataAccess.Repositories.Interfaces;
using Shipfinity.Services.Helpers;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Implementations
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task ResetPasswordAsync(int sellerId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword)
                throw new Exception("New password and confirmation do not match.");

            var seller = await _sellerRepository.GetByIdAsync(sellerId);
            if (seller == null)
                throw new SellerNotFoundException(sellerId);

            if (!seller.VerifyPassword(oldPassword))
                throw new Exception("Old password is incorrect.");

            AuthHelper.HashPassword(newPassword, out byte[] newHash, out byte[] newSalt);
            seller.PasswordHash = newHash;
            seller.PasswordSalt = newSalt;
            await _sellerRepository.UpdateAsync(seller);
        }
    }
}
