

namespace Mardul.Recipes.Core.Interfaces.Services
{
    public interface IPasswordHashService
    {
        string Generate(string password);

        bool Validate(string password, string passwordHash);
    }
}
