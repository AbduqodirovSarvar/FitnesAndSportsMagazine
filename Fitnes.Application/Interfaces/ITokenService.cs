using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Application.Interfaces
{
    public interface ITokenService
    {
        string GetAccessToken(Claim[] claims);
    }
}
