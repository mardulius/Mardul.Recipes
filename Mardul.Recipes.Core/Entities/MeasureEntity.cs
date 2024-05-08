

namespace Mardul.Recipes.Core.Entities
{
    //мера
    public class MeasureEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredientEntity>? RecipeIngridients { get; set; }
    }
}
