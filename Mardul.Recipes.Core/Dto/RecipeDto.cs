
namespace Mardul.Recipes.Core.Dto
{
    public record RecipeDto(int Id, string? Name, DateTime DateCreate, string? Instruction, string? Description, ICollection<RecipeIngredientDto>? Ingredients);
}
