using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desktop.Models;

namespace desktop.Services.Auth
{
    public interface IAuthService
    {
        Task<TokenResponse> LoginAsync(Login login);
        Task<TokenResponse> RegisterAsync(Register register);
    }
}
