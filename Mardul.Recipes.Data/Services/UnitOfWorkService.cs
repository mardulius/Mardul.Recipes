using Mardul.Recipes.Core.Interfaces.Services;
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
