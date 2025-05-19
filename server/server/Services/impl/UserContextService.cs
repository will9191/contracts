using System.Security.Claims;

namespace server.Services.impl
{
    public class UserContextService : IUserContextService
    {
        public Guid GetUserId(ClaimsPrincipal user)
        {
            var userIdStr = user.Claims.FirstOrDefault(c =>
                c.Type == ClaimTypes.NameIdentifier ||
                c.Type == "sub" ||
                c.Type == "userId")?.Value;

            if (string.IsNullOrEmpty(userIdStr))
                throw new Exception("Usuário não autenticado.");

            if (!Guid.TryParse(userIdStr, out var userId))
                throw new Exception("O claim de identificação do usuário não é um GUID válido.");

            return userId;
        }
    }
}
