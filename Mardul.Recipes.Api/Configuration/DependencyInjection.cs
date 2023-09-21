using Mardul.Recipes.Api.Services;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Core.Services;
using Mardul.Recipes.Infrastructure.DbContexts;
using Mardul.Recipes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mardul.Recipes.Api.Configuration
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlite(configuration.GetConnectionString("db"));
                x.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
                x.UseLazyLoadingProxies();

            });

            services.AddAutoMapper(typeof(RecipeMappingProfile));

            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddTransient<IRecipeService, RecipeService>();

            return services;
        }
    }
}
