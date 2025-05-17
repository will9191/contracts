using Microsoft.AspNetCore.Mvc;
using server.Entities;
using server.Models.Requests;
using server.Models.Responses;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Dentro do parênteses é feita a injeção de dependência do service no construtor
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRequestDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user == null)
                return Conflict("Email already exists.");
            
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var response = await authService.LoginAsync(request);

            if (response is null)
                return  BadRequest("Invalid email or password.");

            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken (RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");

            return result;
        }
    }
}
