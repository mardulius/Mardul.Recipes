

namespace Mardul.Recipes.Core.Entities
{
    public class RecipeIngredient : BaseEntity
    {
        public int Amount { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }        
        public int MeasureId { get; set; }
        public virtual Recipe? Recipe { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
        public virtual Measure? Measure { get; set; }
    }

}
