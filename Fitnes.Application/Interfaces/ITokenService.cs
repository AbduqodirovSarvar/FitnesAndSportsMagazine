using System.Security.Claims;

namespace Fitnes.Application.Interfaces
{
    public interface ITokenService
    {
        string GetAccessToken(Claim[] claims);
    }
}
