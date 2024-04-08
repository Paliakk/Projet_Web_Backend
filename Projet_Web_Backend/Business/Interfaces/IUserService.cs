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
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUserAsync();
        Task<UserDTO> GetUserById(int userID);
        Task<IdentityResult> AddAsync(UserAddDTO user, string roleName);
        Task DeleteAsync(int userID);
        Task UpdateAsync(int id,UserUpdateDTO user);
        Task<UserDTO> GetByUsernameAsync(string username);
        Task<string> GetUserRoleAsync(string username);
        Task<IEnumerable<UserDTO>> GetAllStudents();
        Task<IEnumerable<UserDTO>> GetAllInstructors();
        Task<bool> SetUserRoleAsync(int userId, string newRoleName);
    }
}
