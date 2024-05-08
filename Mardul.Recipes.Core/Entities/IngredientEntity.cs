

namespace Mardul.Recipes.Core.Entities
{
    public class IngredientEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredientEntity>? RecipeIngridients { get; set; }
    }
}
