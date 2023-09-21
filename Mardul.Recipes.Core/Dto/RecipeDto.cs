
namespace Mardul.Recipes.Core.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreate { get; set; }
        public string? Instruction { get; set; }
        public string? Description { get; set; }
        public  ICollection<RecipeIngredientDto>? Ingredients { get; set; }
    }
}
