using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Enums;
using Mardul.Recipes.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class RolePermissionConfiguration(AuthorizationAppOptions _authorizationOptions) : IEntityTypeConfiguration<RolePermissionEntity>
    {
        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.HasKey(r => new {r.RoleId, r.PermissionId});
            builder.HasData(ParseRolePermissions());
        }

        private RolePermissionEntity[] ParseRolePermissions()
        {
            return _authorizationOptions.RolePermissions
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermissionEntity
                    {
                        RoleId = (int)Enum.Parse<Role>(rp.Role),
                        PermissionId = (int)Enum.Parse<Permission>(p)
                        
                    })).ToArray();
        }
    }
}
