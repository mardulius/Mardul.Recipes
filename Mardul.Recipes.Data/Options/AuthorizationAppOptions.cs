
namespace Mardul.Recipes.Infrastructure.Options
{
    public class AuthorizationAppOptions
    {
        public RolePermissions[] RolePermissions { get; set; } = [];
    }

    public class RolePermissions
    {
        public string Role { get; set; }
        public string[] Permissions { get; set; } = [];
    }
}
