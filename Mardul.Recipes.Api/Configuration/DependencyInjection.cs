using Mardul.Recipes.Api.Services;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Core.Services;
using Mardul.Recipes.Infrastructure.Authentication;
using Mardul.Recipes.Infrastructure.DbContexts;
using Mardul.Recipes.Infrastructure.Repositories;
using Mardul.Recipes.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Mardul.Recipes.Api.Configuration
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);

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

        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            var section = configuration.GetSection("JwtOptions");
            section.Bind(jwtOptions);
            
            services.Configure<JwtOptions>(section);

            services.AddSingleton<ITokenService,TokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = jwtOptions.Issuer,
                    ValidIssuer = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Key)),
                };
            });

            return services;
        }
    }
}
