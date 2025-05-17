using System.Security.Claims;

namespace server.Services.impl
{
    public class UserContextService : IUserContextService
    {
        public Guid GetUserId(ClaimsPrincipal user)
        {
            var userIdStr = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userIdStr == null)
                throw new Exception("Usuário não autenticado.");

            return Guid.Parse(userIdStr);
        }
    }
}
