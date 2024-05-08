
namespace Mardul.Recipes.Core.Entities
{
    public class RecipeEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instruction { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<RecipeIngredientEntity>? Ingredients { get; set; }
    }
}
