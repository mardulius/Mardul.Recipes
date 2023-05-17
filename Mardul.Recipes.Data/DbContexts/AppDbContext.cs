using Mardul.Recipes.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Mardul.Recipes.Data.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
