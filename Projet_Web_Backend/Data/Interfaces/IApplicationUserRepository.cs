using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUserAsync();
        Task<ApplicationUser> GetUserById(int userID);
        Task<IdentityResult> AddAsync(ApplicationUser user, string password, string roleName);
        Task DeleteAsync(int userID);
        Task UpdateAsync(ApplicationUser user);
        Task<ApplicationUser> GetByUsernameAsync(string username);
        Task<string> GetUserRoleAsync(string username);
        Task<IEnumerable<ApplicationUser>> GetAllStudents();
        Task<IEnumerable<ApplicationUser>> GetAllInstructors();
        Task<IdentityResult> SetUserRoleAsync(int userID, string roleName);

    }
}
