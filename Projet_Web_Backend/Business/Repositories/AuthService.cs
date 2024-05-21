using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthService(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<LoginResponsetDTO> LoginAsync(LoginRequestDTO request)
        {
            ApplicationUser identityUser = request.Login.Contains("@") ?
                await _authRepository.FindByEmailAsync(request.Login) :
                await _authRepository.FindByNameAsync(request.Login);

            if (identityUser != null && await _authRepository.CheckPasswordAsync(identityUser, request.Password))
            {
                var roles = await _authRepository.GetRolesAsync(identityUser);
                var (jwtToken, refreshToken) = _tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                return new LoginResponsetDTO
                {
                    Id = identityUser.Id,
                    Email = identityUser.Email,
                    Roles = roles.ToList(),
                    Token = jwtToken,
                    RefreshToken = refreshToken
                };
            }

            return null;
        }

        public async Task<IdentityResult> RegisterAsync(RegistrationRequestDTO request)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName?.Trim(),
                Email = request.Email?.Trim()
            };
            var identityResult = await _authRepository.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await _authRepository.AddToRoleAsync(user, "student");
            }

            return identityResult;
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
            return await _authRepository.FindByNameAsync(username);
        }
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _authRepository.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _authRepository.GetRolesAsync(user);
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await _authRepository.UpdateAsync(user);
        }
        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            return await _authRepository.ChangePasswordAsync(user, currentPassword, newPassword);
        }
        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _authRepository.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            return await _authRepository.ResetPasswordAsync(user, token, newPassword);
        }


    }
}
