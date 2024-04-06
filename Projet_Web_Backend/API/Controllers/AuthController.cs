using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;
        public AuthController(UserManager<ApplicationUser> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        public ITokenRepository TokenRepository { get; }

        // POST : {apibaseurl}/api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            //verif email
            ApplicationUser identityUser = null;
            // Vérifie si le Login est un email
            if (request.Login.Contains("@"))
            {
                identityUser = await userManager.FindByEmailAsync(request.Login);
            }
            else
            {
                identityUser = await userManager.FindByNameAsync(request.Login);
            }

            if (identityUser is not null)
            {
                //Verif mdp
                var checkPasswordResult =  await userManager.CheckPasswordAsync(identityUser, request.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);
                    //creation de token et reponse
                    var jwtToken = tokenRepository.CreateJwtToken(identityUser, roles.ToList());
                    var response = new LoginResponsetDTO()
                    {
                        Email = identityUser.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
            }
            ModelState.AddModelError("","Email or Password incorrect");

            return ValidationProblem(ModelState);
        }


        // POST : {apibaseurl}/api/auth/register
        [HttpPost]
        [Route ("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO request)
        {
            //Create IdentityUser object 
            var user = new ApplicationUser
            {
                UserName = request.UserName?.Trim(),
                Email = request.Email?.Trim()
            };
            // Create User
            var identityResult =  await userManager.CreateAsync(user,request.Password);

            if (identityResult.Succeeded)
            {
                // Add role to user (student)
                identityResult = await userManager.AddToRoleAsync(user, "student");

                if(identityResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if(identityResult.Errors.Any())
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return ValidationProblem(ModelState);
        }
    }
}
