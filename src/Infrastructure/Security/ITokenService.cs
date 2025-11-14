using Domain.Entities;
using System.Security.Claims;

namespace Infrastructure.Security
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
