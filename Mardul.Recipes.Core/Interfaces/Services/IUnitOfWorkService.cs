

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IUnitOfWorkService
    {
        Task<int> SaveChangesAsync();
    }
}
