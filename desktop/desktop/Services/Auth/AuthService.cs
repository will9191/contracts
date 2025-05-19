using desktop.Models;
using desktop.Services.RequestProvider;

namespace desktop.Services.Auth
{
    public class AuthService(IRequestProvider requestProvider): IAuthService
    {
        private readonly IRequestProvider _requestProvider = requestProvider;

        public async Task<TokenResponse> LoginAsync(Login login)
        {
            var uri = GlobalSettings.Instance.AuthEndpoint + "/login";
            return await _requestProvider.PostAsync<TokenResponse, Login>(uri, login);
        }

        public async Task<TokenResponse> RegisterAsync(Register register)
        {
            var uri = GlobalSettings.Instance.AuthEndpoint + "/register";
            return await _requestProvider.PostAsync<TokenResponse, Register>(uri, register);
        }
    }
}
