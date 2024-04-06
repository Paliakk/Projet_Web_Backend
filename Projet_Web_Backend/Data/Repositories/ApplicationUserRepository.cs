using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUserAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
        public async Task<ApplicationUser> GetUserById(int userID)
        {
            var user = await _userManager.FindByIdAsync(userID.ToString());
            return user;
        }
        public async Task<IdentityResult> AddAsync(ApplicationUser user, string password,string roleName)
        {
            var userToCreate = await _userManager.CreateAsync(user,password);
            if (!userToCreate.Succeeded)
            {
                return userToCreate; // Retourne le résultat si la création de l'utilisateur échoue
            }
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                throw new KeyNotFoundException(roleName);
            }
            var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!addToRoleResult.Succeeded)
            {
                return addToRoleResult; // Retourne le résultat si l'ajout au rôle échoue
            }
            return IdentityResult.Success;
        }
        public async Task DeleteAsync(int userID)
        {
            var user = await _userManager.FindByIdAsync(userID.ToString());
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Une erreur s'est produite lors de la suppression de l'utilisateur.");
                }
            }
            else
            {
                throw new KeyNotFoundException("Utilisateur non trouvé.");
            }
        }
        public async Task UpdateAsync(ApplicationUser user)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.Id.ToString());
            if (userToUpdate == null)
            {
                // Gérez le cas où l'utilisateur n'existe pas. Par exemple, lancez une exception ou retournez un résultat spécifique.
                throw new KeyNotFoundException("Utilisateur non trouvé avec l'ID spécifié.");
            }
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // La mise à jour a échoué, gérez les erreurs ici. Par exemple, loggez-les ou lancez une exception.
                throw new InvalidOperationException("Échec de la mise à jour de l'utilisateur.");
            }
        }
        public async Task<ApplicationUser> GetByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }
        public async Task<string> GetUserRoleAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new KeyNotFoundException($"Aucun utilisateur trouvé avec le nom d'utilisateur {username}.");
            }
            var roles = await _userManager.GetRolesAsync(user);

            return roles.FirstOrDefault();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllStudents()
        {
            var users = await _userManager.Users.ToListAsync();
            var students = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    students.Add(user);
                }
            }
            return students;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllInstructors()
        {
            var users = await _userManager.Users.ToListAsync();
            var instructors = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Instructor"))
                {
                    instructors.Add(user);
                }
            }
            return instructors;
        }
        public async Task<IdentityResult> SetUserRoleAsync(int userID, string roleName)
        {
            //Trouver l'utilisateur
            var user = await _userManager.FindByIdAsync(userID.ToString());
            if (user == null)
            {
                throw new KeyNotFoundException($"Utilisateur non trouvé avec l'ID {userID}.");
            }
            // Vérifier si le rôle existe
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                throw new KeyNotFoundException(roleName);
            }
            //Obtenir les rôles actuels et les supprimer
            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeFromRolesResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeFromRolesResult.Succeeded)
            {
                return removeFromRolesResult;
            }
            // Ajouter l'utilisateur au nouveau rôle
            var addToRoleResult = await _userManager.AddToRoleAsync(user, roleName);
            return addToRoleResult;
        }
    }
}
