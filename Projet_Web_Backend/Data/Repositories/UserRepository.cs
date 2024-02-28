using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Data;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BackendContext _context;
        private string secretKey;

        public UserRepository(BackendContext context, IConfiguration configuration)
        {
            _context = context;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret") ?? string.Empty;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.LocalUsers.FirstOrDefault(x => x.LocalUserUsername == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public async Task<LoginResponsetDTO> Login(LoginRequestDTO loginResuestDTO)
        {
            if(loginResuestDTO ==null)
            {
                throw new ArgumentNullException(nameof(loginResuestDTO));
            }
            var user = _context.LocalUsers.FirstOrDefault(u => u.LocalUserUsername.ToLower() == loginResuestDTO.Username.ToLower()
            && u.LocalUserPassword == loginResuestDTO.Password);

            if(user == null)
            {
                return new LoginResponsetDTO()
                {
                    Token ="",
                    User =null
                };
            }
            //If user is found, create token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.LocalUserId.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponsetDTO loginResponsetDTO = new LoginResponsetDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponsetDTO;
        }
        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                LocalUserUsername = registrationRequestDTO.Username,
                LocalUserPassword = registrationRequestDTO.Password,
                Role = registrationRequestDTO.Role
            };
            _context.LocalUsers.Add(user);
            _context.SaveChanges();
            user.LocalUserPassword ="";
            return user;
        }
    }
}