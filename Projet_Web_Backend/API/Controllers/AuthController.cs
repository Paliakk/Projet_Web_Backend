﻿using Business.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        // POST : {apibaseurl}/api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var response = await _authService.LoginAsync(request);
            if (response != null)
            {
                return Ok(response);
            }
            ModelState.AddModelError("", "Email or Password incorrect");
            return ValidationProblem(ModelState);
        }

        // POST : {apibaseurl}/api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO request)
        {
            var identityResult = await _authService.RegisterAsync(request);
            if (identityResult.Succeeded)
            {
                return Ok();
            }

            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return ValidationProblem(ModelState);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.Token);
            var username = principal.Identity.Name;

            var user = await _authService.FindByNameAsync(username);
            if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid token information");
            }

            var roles = await _authService.GetRolesAsync(user);
            var (newJwtToken, newRefreshToken) = _tokenService.CreateJwtToken(user, roles.ToList());

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddHours(2);
            await _authService.UpdateUserAsync(user);

            var response = new LoginResponsetDTO
            {
                Email = user.Email,
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
                Roles = roles.ToList()
            };

            return Ok(response);
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            var user = await _authService.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var result = await _authService.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return ValidationProblem(ModelState);
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDTO request)
        {
            var user = await _authService.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var token = await _authService.GeneratePasswordResetTokenAsync(user);
            // Enregistrez le token dans une table temporaire ou en mémoire avec une expiration

            return Ok(new { token });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _authService.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid request" });
            }

            var result = await _authService.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Password has been reset successfully" });
        }
    }
}