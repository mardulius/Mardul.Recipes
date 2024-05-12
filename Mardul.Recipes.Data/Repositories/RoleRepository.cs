using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Infrastructure.Repositories
{
    public class RoleRepository(DbContext dbContext) : GenericRepository<RoleEntity>(dbContext), IRoleRepository
    {

    }
}
