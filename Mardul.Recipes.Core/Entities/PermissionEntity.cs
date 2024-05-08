
namespace Mardul.Recipes.Core.Entities
{
    public class PermissionEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; } = [];
      
    }
}
