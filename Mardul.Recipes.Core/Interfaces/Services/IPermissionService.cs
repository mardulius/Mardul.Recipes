
using Mardul.Recipes.Core.Enums;

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IPermissionService
    {
        Task <IEnumerable<Permission>> GetPermissionsAsync(int userId);
    }
}
