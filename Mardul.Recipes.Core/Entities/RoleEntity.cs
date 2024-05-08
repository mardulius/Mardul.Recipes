
namespace Mardul.Recipes.Core.Entities
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; } = [];
        public virtual ICollection<PermissionEntity> Permissions { get; set; } = [];
    }
}
