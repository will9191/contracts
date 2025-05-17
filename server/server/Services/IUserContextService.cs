using System.Security.Claims;

namespace server.Services
{
    public interface IUserContextService
    {
        Guid GetUserId(ClaimsPrincipal user);
    }
}
