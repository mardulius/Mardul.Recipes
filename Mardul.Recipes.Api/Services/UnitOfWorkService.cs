using Mardul.Recipes.Data.DbContexts;
using Mardul.Recipes.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Api.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly DbContext _dbContext;
       
        public UnitOfWorkService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
