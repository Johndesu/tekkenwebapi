using Microsoft.AspNetCore.Identity;

namespace TekkenPortugal.WebApi.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
