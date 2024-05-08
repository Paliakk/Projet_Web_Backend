using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class RefreshTokenRequestDTO
    {
        public string Token { get; set; }  // Le token actuel (expiré)
        public string RefreshToken { get; set; }  // Le refresh token
    }
}
