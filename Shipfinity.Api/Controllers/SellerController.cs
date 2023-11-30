using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(int sellerId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            try
            {
                await _sellerService.ResetPasswordAsync(sellerId, oldPassword, newPassword, confirmNewPassword);
                return Ok("Password successfully reset.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
