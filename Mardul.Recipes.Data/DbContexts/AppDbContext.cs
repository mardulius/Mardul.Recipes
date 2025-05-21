using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Infrastructure.DbContexts.Configurations;
using Mardul.Recipes.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Mardul.Recipes.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IOptions<AuthorizationAppOptions> _authorizationOptions;

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<MeasureEntity> Measures { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<AuthorizationAppOptions> authorizationOptions) : base(options)
        {
            _authorizationOptions = authorizationOptions;
            Database.EnsureCreated();
            Database.Migrate();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MeasureConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(_authorizationOptions.Value));


            modelBuilder.Entity<MeasureEntity>().HasData(
                [
                    new MeasureEntity { Id = 1, Name = "ч. л." },
                    new MeasureEntity { Id = 2, Name = "ст. л." },
                    new MeasureEntity { Id = 3, Name = "ст." },
                    new MeasureEntity { Id = 4, Name = "гр." },
                    new MeasureEntity { Id = 5, Name = "л." },
                    new MeasureEntity { Id = 6, Name = "мл." }
                ]);

            modelBuilder.Entity<IngredientEntity>().HasData(
                [
                    new IngredientEntity { Id = 1, Name = "Молоко"},
                    new IngredientEntity { Id = 2, Name = "Мука"},
                    new IngredientEntity { Id = 3, Name = "Вода"},
                    new IngredientEntity { Id = 4, Name = "Соль"},
                ]);
        }

    }
}

