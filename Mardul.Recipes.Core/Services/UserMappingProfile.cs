using AutoMapper;
using Mardul.Recipes.Core.Dto.Accounts;
using Mardul.Recipes.Core.Entities;

namespace Mardul.Recipes.Core.Services
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<RegisterRequestDto, UserEntity>();
        }
    }
}
