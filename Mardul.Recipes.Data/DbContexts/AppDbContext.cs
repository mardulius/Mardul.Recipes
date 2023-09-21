using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Mardul.Recipes.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measure>().HasData(
                new Measure[]
                {
                    new Measure { Id = 1, Name = "ч. л." },
                    new Measure { Id = 2, Name = "ст. л." },
                    new Measure { Id = 3, Name = "ст." },
                    new Measure { Id = 4, Name = "гр." },
                    new Measure { Id = 5, Name = "л." },
                    new Measure { Id = 6, Name = "мл." }
                });
        }

    }
}

