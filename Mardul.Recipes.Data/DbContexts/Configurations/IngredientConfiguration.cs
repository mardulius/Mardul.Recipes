using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<IngredientEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(i => i.RecipeIngridients)
                .WithOne(r => r.Ingredient);
        }
    }

}
