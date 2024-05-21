using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITokenService
    {
        (string Token, string RefreshToken) CreateJwtToken(ApplicationUser user, List<string> roles);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
    }
}
