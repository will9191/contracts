using server.Entities;
using server.Models.Requests;
using server.Models.Responses;

namespace server.Services
{
    public interface IAuthService
    {
        Task<TokenResponseDto?> RegisterAsync(UserRequestDto request);
        Task<TokenResponseDto?> LoginAsync(LoginRequestDto request);
        Task<TokenResponseDto?> RefreshTokensAsync(RefreshTokenRequestDto request);
    }
}
