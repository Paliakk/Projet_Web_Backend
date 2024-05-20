using Business.Interfaces;
using Business.Repositories;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    }
}