using Shipfinity.DTOs.SellerDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipfinity.Services.Interfaces
{
    public interface ISellerService
    {
        Task ResetPasswordAsync(SellerPasswordResetDto passwordResetDto);
    }
}
