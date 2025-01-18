using BankManagementAPI.DTOs;
using BankManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(loginDto.Email, loginDto.Password);
                if (user == null)
                    return Unauthorized(new { Message = "Invalid credentials" });

                var token = _tokenService.GenerateToken(user.Id.ToString(), user.Role);
                return Ok(new { Token = token, Role = user.Role, UserId = user.Id });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var result = await _userService.RegisterUserAsync(userDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}
