using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(i => i.RecipeIngridients)
                .WithOne(r => r.Ingredient);
        }
    }

}
