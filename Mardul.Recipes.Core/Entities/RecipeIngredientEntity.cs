

namespace Mardul.Recipes.Core.Entities
{
    public class RecipeIngredientEntity : BaseEntity
    {
        public int Amount { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }        
        public int MeasureId { get; set; }
        public virtual RecipeEntity? Recipe { get; set; }
        public virtual IngredientEntity? Ingredient { get; set; }
        public virtual MeasureEntity? Measure { get; set; }
    }

}
