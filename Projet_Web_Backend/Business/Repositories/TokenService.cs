using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public (string Token, string RefreshToken) CreateJwtToken(ApplicationUser user, List<string> roles)
        {
            return _tokenRepository.CreateJwtToken(user, roles);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            return _tokenRepository.GetPrincipalFromExpiredToken(token);
        }

        public string GenerateRefreshToken()
        {
            return _tokenRepository.GenerateRefreshToken();
        }
    }
}
