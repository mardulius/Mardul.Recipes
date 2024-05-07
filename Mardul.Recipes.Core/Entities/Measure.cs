

namespace Mardul.Recipes.Core.Entities
{
    //мера
    public class Measure : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<RecipeIngredient>? RecipeIngridients { get; set; }
    }
}
