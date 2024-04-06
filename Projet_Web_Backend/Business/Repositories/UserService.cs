using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class UserService : IUserService
    {
        private readonly IApplicationUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IApplicationUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUserAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<UserDTO> GetUserById(int userID)
        {
            var user = await _userRepository.GetUserById(userID);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<IdentityResult> AddAsync(UserAddDTO user,string roleName)
        {
            var userToAdd = _mapper.Map<ApplicationUser>(user);
            return await _userRepository.AddAsync(userToAdd,user.Password,roleName);
        }
        //Pas besoin de DTO pour un delete
        public async Task DeleteAsync(int userID)
        {
            await _userRepository.DeleteAsync(userID);
        }
        public async Task UpdateAsync(UserUpdateDTO user)
        {
            var userToUpdate = await _userRepository.GetUserById(user.Id);
            if (userToUpdate == null)
            {
                throw new KeyNotFoundException("Utilisateur non trouvé avec l'ID spécifié.");
            }
            _mapper.Map(user, userToUpdate);
            await _userRepository.UpdateAsync(userToUpdate);
        }
        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<string> GetUserRoleAsync(string username)
        {
            var roles = await _userRepository.GetUserRoleAsync(username);
            return roles;
        }
        public async Task<IEnumerable<UserDTO>> GetAllStudents()
        {
            var students = await _userRepository.GetAllStudents();
            return _mapper.Map<IEnumerable<UserDTO>>(students);
        }
        public async Task<IEnumerable<UserDTO>> GetAllInstructors()
        {
            var instructors = await _userRepository.GetAllInstructors();
            return _mapper.Map<IEnumerable<UserDTO>>(instructors);
        }
        public async Task<bool> SetUserRoleAsync(int userId, string newRoleName)
        {
            var result = await _userRepository.SetUserRoleAsync(userId, newRoleName);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
