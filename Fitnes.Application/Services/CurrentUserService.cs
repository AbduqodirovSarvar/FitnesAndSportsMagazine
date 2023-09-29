using Fitnes.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Fitnes.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public CurrentUserService(IHttpContextAccessor _contextAccessor)
        {
            var httpContext = _contextAccessor.HttpContext;
            var userClaims = httpContext?.User.Claims;
            var idClaim = userClaims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null && int.TryParse(idClaim.Value, out int value))
            {
                UserId = value;
            }
        }
    }
}
