﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shipfinity.DTOs.CustomerDTOs;
using Shipfinity.DTOs.SellerDTO_s;
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
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
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
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("seller/register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterSeller(SellerRegisterDto dto)
        {
            try
            {
                await _authService.RegisterSeller(dto);
                return StatusCode(StatusCodes.Status201Created, "Seller created");
            }
            catch (UserRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("seller/login")]
        [AllowAnonymous]
        public async Task<ActionResult<SellerLoginResponseDto>> LoginSeller(UserLoginDto dto)
        {
            try
            {
                return Ok(await _authService.LoginSeller(dto));
            }
            catch (BadCredentialsException ex)
            {
                return BadRequest("Bad credentials");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("init")]
        [AllowAnonymous]
        public async Task<IActionResult> Init(SellerRegisterDto dto)
        {
            try
            {
                if (await _authService.InitialAdmin(dto))
                    return StatusCode(StatusCodes.Status201Created, "Admin initialized");
                return BadRequest("Admin already exists");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
