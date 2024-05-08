using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredientEntity>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredientEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients);

            builder
                .HasOne(r => r.Ingredient)
                .WithMany(i => i.RecipeIngridients);

            builder
                .HasOne(r => r.Measure)
                .WithMany(m => m.RecipeIngridients);
        }
    }

}
