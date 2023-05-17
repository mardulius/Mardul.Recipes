using AutoMapper;
using Mardul.Recipes.Api.Dto;
using Mardul.Recipes.Data.Entities;

namespace Mardul.Recipes.Api.Services
{
    public class RecipeService : IRecipeService
    {
        #region DI

        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWorkService unitOfWorkService, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _mapper = mapper;
        }

        #endregion
        public async Task Add(RecipeDto recipe)
        {
            var newRecipe = _mapper.Map<RecipeDto>(recipe);
            List<RecipeIngredient> ingredients = new List<RecipeIngredient>();
            foreach (var item in recipe.Ingredients)
            {
                ingredients.Add(_mapper.Map<RecipeIngredient>(item));
            }
        }

        public async Task<IEnumerable<RecipeDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
