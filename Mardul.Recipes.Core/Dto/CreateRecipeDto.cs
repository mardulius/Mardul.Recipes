using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mardul.Recipes.Core.Dto
{
    public record CreateRecipeDto(string Name, DateTime DateCreate, string Instruction, string? Description, ICollection<CreateRecipeIngredientDto>? Ingredients);

}
