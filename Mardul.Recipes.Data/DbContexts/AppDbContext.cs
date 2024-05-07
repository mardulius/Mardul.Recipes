using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Infrastructure.DbContexts.Configurations;
using Microsoft.EntityFrameworkCore;


namespace Mardul.Recipes.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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


            modelBuilder.Entity<Measure>().HasData(
                [
                    new Measure { Id = 1, Name = "ч. л." },
                    new Measure { Id = 2, Name = "ст. л." },
                    new Measure { Id = 3, Name = "ст." },
                    new Measure { Id = 4, Name = "гр." },
                    new Measure { Id = 5, Name = "л." },
                    new Measure { Id = 6, Name = "мл." }
                ]);

            modelBuilder.Entity<Ingredient>().HasData(
                [
                    new Ingredient { Id = 1, Name = "Молоко"},
                    new Ingredient { Id = 2, Name = "Мука"},
                    new Ingredient { Id = 3, Name = "Вода"},
                    new Ingredient { Id = 4, Name = "Соль"},
                ]);
        }

    }
}

