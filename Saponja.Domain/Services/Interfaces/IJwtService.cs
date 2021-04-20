using Saponja.Data.Entities.Models;

namespace Saponja.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GetJwtTokenForUser(User user);
        string GetNewToken(string token);
    }
}
