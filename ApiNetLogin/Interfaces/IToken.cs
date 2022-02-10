using System.Security.Claims;

namespace ApiNetLogin.Interfaces
{
    public interface IToken
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
