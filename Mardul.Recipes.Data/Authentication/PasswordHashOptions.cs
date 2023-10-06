

using System.Security.Cryptography;

namespace Mardul.Recipes.Infrastructure.Authentication
{
    public class PasswordHashOptions
    {
        public int SaltSize { get; init; }
        public int KeySize { get; init; }
        public int Iterations { get; init; }
        public char SaltDelimeter { get; init; }
        public HashAlgorithmName HashAlgorithmName { get; init; } = HashAlgorithmName.SHA256;

    }
}
