
using FakeItEasy;
using FluentAssertions;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace Mardul.Recipes.Tests.Services
{
    public class PasswordHashServiceTest
    {
        private readonly PasswordHashOptions _options;
        public const string _password = "Qwerty123!";
        public const string _hashPassword = "0qcVx8uFFSm1VMlrFfYd0g==;lINnHFdzZYWdKcn9cCgnIfwSgh8UmPj9fF6UmDjY1Pk=";
        public PasswordHashServiceTest()
        {
           _options = new PasswordHashOptions() 
           { 
               SaltSize = 16,
               SaltDelimeter = ';',
               Iterations = 1000,
               KeySize = 32
           };
        }

        [Theory]
        [InlineData(_password)]
        public async Task PasswordHashService_Generate_returnToken(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_options.SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iterations, _options.HashAlgorithmName, _options.KeySize);

            var result = string.Join(_options.SaltDelimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));

            result.Should().NotBeNull();
            result.Should().BeOfType<string>();
            result.Should().ContainAny(";");
        }

        [Theory]
        [InlineData(_password, _hashPassword)]
        public async Task PasswordHashService_Validate_returnTrue(string password, string passwordHash)
        {

            var pwdElements = passwordHash.Split(_options.SaltDelimeter);

            var salt = Convert.FromBase64String(pwdElements[0]);
            var hash = Convert.FromBase64String(pwdElements[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, _options.Iterations, _options.HashAlgorithmName, _options.KeySize);

            var result = CryptographicOperations.FixedTimeEquals(hash, hashInput);

            result.Should().BeTrue();

        }
    }
}
