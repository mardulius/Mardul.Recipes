using Mardul.Recipes.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Mardul.Recipes.Infrastructure.Authentication
{
    public class PermissionRequirement(Permission[] permissions) : IAuthorizationRequirement
    {
        public Permission[] Permissions { get; set; } = permissions;
    }
}
