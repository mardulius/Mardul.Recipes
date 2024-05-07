

namespace Mardul.Recipes.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<RecipeIngredient>? RecipeIngridients { get; set; }
    }
}
