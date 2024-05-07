
namespace Mardul.Recipes.Core.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instruction { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<RecipeIngredient>? Ingredients { get; set; }
    }
}
