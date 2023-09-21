using Mardul.Recipes.Core.Dto;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Core.Entities;
using Mardul.Recipes.Core.Interfaces.Repositories;
using AutoMapper;

namespace Mardul.Recipes.Core.Services
{
    public class RecipeService : IRecipeService
    {
        #region DI

        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWorkService unitOfWorkService, IRecipeRepository recipeRepository, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<bool> Add(RecipeDto recipe)
        {
            var newRecipe = _mapper.Map<Recipe>(recipe);
            
            await _recipeRepository.Add(newRecipe);
            var saved = await _unitOfWorkService.SaveChangesAsync();
            
            return saved > 0 ? true : false;

        }

        public async Task<IEnumerable<RecipeDto>> GetAll()
        {
            var recipes = await _recipeRepository.GetAll();

            return _mapper.Map<IEnumerable<RecipeDto>>(recipes);
        }

        public async Task<RecipeDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
