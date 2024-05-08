using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("GetAllUsers")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userService.GetAllUserAsync();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet]
        [Route("GetUserById{userID:int}")]
        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin,Student,Instructor")]
        public async Task<ActionResult<ApplicationUser>> GetUserById([FromRoute] int userID)
        {
            try
            {
                var user = await _userService.GetUserById(userID);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("AddUser")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<ActionResult<IdentityResult>> CreateUser([FromBody] UserAddDTO user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest(user);
                }
                await _userService.AddAsync(user,user.RoleName);
                return Created("", user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating user");
            }
        }
        [HttpDelete]
        [Route("DeleteUser{userID:int}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userID)
        {
            try
            {
                var user = await _userService.GetUserById(userID);

                if (user == null)
                {
                    return NotFound();
                }
                //Convert Domain
                await _userService.DeleteAsync(userID);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting user record");
            }
        }
        [HttpPut("Update/{id:int}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            try
            {
                await _userService.UpdateAsync(id,userUpdateDTO);
                return NoContent(); // Retourne un succès sans contenu, indiquant que la mise à jour a réussi
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Ou retournez un code d'état différent selon votre logique d'erreur
            }
        }
        [HttpGet("GetByUsername/{username}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<ActionResult<UserDTO>> GetByUsername([FromRoute] string username)
        {
            try
            {
                var user = await _userService.GetByUsernameAsync(username);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetUserRoles{username}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<ActionResult<string>> GetUserRoles([FromRoute] string username)
        {
            try
            {
                var roles = await _userService.GetUserRoleAsync(username);
                if(roles == null)
                {
                    return NotFound();
                }
                return Ok(roles.ToString());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
        [HttpGet("GetAllStudents")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        //[Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllStudents()
        {
            try
            {
                var students = await _userService.GetAllStudents();
                if (students == null || !students.Any())
                {
                    return NotFound("No students found.");
                }
                return Ok(students);
            }
            catch (Exception ex)
            {
                // Log l'exception si nécessaire
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
        [HttpGet("GetAllInstructors")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllInstructors()
        {
            try
            {
                var instructors = await _userService.GetAllInstructors();
                if (instructors == null || !instructors.Any())
                {
                    return NotFound("No instructors found.");
                }
                return Ok(instructors);
            }
            catch (Exception ex)
            {
                // Log l'exception si nécessaire
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }
        [HttpPost("SetUserRole")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> SetUserRole(int userId, string newRoleName)
        {
            var success = await _userService.SetUserRoleAsync(userId, newRoleName);
            if (success)
            {
                return Ok("Rôle mis à jour avec succès.");
            }
            return BadRequest("Impossible de mettre à jour le rôle de l'utilisateur.");
        }
    }
}
