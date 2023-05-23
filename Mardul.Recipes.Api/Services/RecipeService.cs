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
            var newRecipe = _mapper.Map<Recipe>(recipe);
            await _unitOfWorkService.RecipeRepository.Add(newRecipe);
           await  _unitOfWorkService.Save();
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
