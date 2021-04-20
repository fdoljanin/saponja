using Microsoft.AspNetCore.Authorization;
using Saponja.Data.Enums;

namespace Saponja.Web.Infrastructure.AuthorizationRequirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public UserRole Role { get; set; }

        public RoleRequirement(UserRole role)
        {
            Role = role;
        }
    }
}
