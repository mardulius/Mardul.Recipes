using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Mardul.Recipes.Infrastructure.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        #region DI

        private readonly PasswordHashOptions _options;
        public PasswordHashService(IOptions<PasswordHashOptions> options)
        {
            _options = options.Value;
        }

        #endregion


        public string Generate(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_options.SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iterations, _options.HashAlgorithmName, _options.KeySize);

            return string.Join(_options.SaltDelimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        public bool Validate(string password, string passwordHash)
        {
            var pwdElements = passwordHash.Split(_options.SaltDelimeter);

            var salt = Convert.FromBase64String(pwdElements[0]);
            var hash = Convert.FromBase64String(pwdElements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iterations, _options.HashAlgorithmName, _options.KeySize);
            
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);
        }
    }
}
