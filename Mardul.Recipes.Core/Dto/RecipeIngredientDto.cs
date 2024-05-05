
namespace Mardul.Recipes.Core.Dto
{
    public record RecipeIngredientDto(int Id, int Amount, int MeasureId, string? MeasureName, int IngredientId, string? IngredientName);
}