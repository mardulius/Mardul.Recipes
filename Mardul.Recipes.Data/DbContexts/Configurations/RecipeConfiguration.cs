using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe);

        }
    }

}
