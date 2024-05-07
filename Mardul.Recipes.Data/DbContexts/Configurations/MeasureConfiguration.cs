using Mardul.Recipes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mardul.Recipes.Infrastructure.DbContexts.Configurations
{
    public class MeasureConfiguration : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(m => m.RecipeIngridients)
                .WithOne(r => r.Measure);
        }
    }

}
