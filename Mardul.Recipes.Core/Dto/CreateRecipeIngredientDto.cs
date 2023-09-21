using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Dto
{
    public record CreateRecipeIngredientDto(int Amount, int MeasureId, int IngredientId);

}