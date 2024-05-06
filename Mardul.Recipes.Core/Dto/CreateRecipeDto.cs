
namespace Mardul.Recipes.Core.Dto
{
    public record CreateRecipeDto(string Name, DateTime DateCreate, string Instruction, string? Description, ICollection<CreateRecipeIngredientDto>? Ingredients);

}
