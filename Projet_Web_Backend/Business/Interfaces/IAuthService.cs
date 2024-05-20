using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponsetDTO> LoginAsync(LoginRequestDTO request);
        Task<IdentityResult> RegisterAsync(RegistrationRequestDTO request);
        Task<ApplicationUser> FindByNameAsync(string username);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task UpdateUserAsync(ApplicationUser user);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    }
}
