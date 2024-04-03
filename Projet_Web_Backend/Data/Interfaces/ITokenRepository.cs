using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(ApplicationUser user,List<string> roles);
    }
}
