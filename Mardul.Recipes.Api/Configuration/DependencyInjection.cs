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
using Microsoft.OpenApi.Models;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace Mardul.Recipes.Api.Configuration
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            services.AddCustomAuthentication(configuration);

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlite(configuration.GetConnectionString("db"));
                x.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
                x.UseLazyLoadingProxies();

            });
            services.AddScoped<DbContext, AppDbContext>();

            services.AddAutoMapper(typeof(RecipeMappingProfile));
            services.AddAutoMapper(typeof(UserMappingProfile));

            var section = configuration.GetSection("PasswordHashOptions");
            services.Configure<PasswordHashOptions>(section);

            services.AddCustomServices();
            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = new JwtOptions();
            var section = configuration.GetSection("JwtOptions");
            section.Bind(jwtOptions);

            services.Configure<JwtOptions>(section);

            services.AddSingleton<ITokenService, TokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Key)),
                };
            });

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordHashService, PasswordHashService>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
