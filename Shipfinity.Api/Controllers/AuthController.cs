using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shipfinity.DTOs.CustomerDTOs;
using Shipfinity.DTOs.UserDTOs;
using Shipfinity.Services.Interfaces;
using Shipfinity.Shared.Exceptions;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("customer/register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCustomer(CustomerRegisterDto dto)
        {
            try
            {
                await _authService.RegisterCustomer(dto);
                return StatusCode(StatusCodes.Status201Created, "User created");
            }
            catch(UserRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("customer/login")]
        [AllowAnonymous]
        public async Task<ActionResult<CustomerLoginResponseDto>> LoginCustomer(UserLoginDto dto)
        {
            try
            {
                return Ok(await _authService.LoginCustomer(dto));
            }
            catch(BadCredentialsException ex)
            {
                return BadRequest("Bad credentials");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
