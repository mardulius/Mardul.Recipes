
namespace Mardul.Recipes.Api.Dto
{
    public class RecipeIngredientDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? MeasureName { get; set; }
        public string? IngredientName { get; set; }

    }
}