using Data.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        var loginResponse = await _userRepository.Login(loginRequestDTO);
        if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        return Ok(loginResponse);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
    {
        if (registrationRequestDTO.Username == null)
        {
            return BadRequest(new { message = "Username cannot be null" });
        }

        bool ifUserNameUnique = _userRepository.IsUniqueUser(registrationRequestDTO.Username);
        if (!ifUserNameUnique)
        {
            return BadRequest(new { message = "Username already exists" });
        }
        var user = await _userRepository.Register(registrationRequestDTO);
        if (user == null)
        {
            return StatusCode(500, new { message = "Error while registering user" });
        }
        return Ok(user);
    }
}