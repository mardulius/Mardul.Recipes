using FakeItEasy;
using FluentAssertions;
using Mardul.Recipes.Infrastructure.Authentication;
using Mardul.Recipes.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace Mardul.Recipes.Tests.Services
{
    public class PasswordHashServiceTest
    {
        private readonly PasswordHashService _passwordHashService;
        private readonly IOptions<PasswordHashOptions> _options;
        public const string _password = "Qwerty123!";
        public const string _hashPassword = "0qcVx8uFFSm1VMlrFfYd0g==;lINnHFdzZYWdKcn9cCgnIfwSgh8UmPj9fF6UmDjY1Pk=";
        public PasswordHashServiceTest()
        {
            _options = Options.Create(new PasswordHashOptions 
            {
                SaltSize = 16,
                KeySize= 32,
                SaltDelimeter = ';',
                Iterations = 1000
            });
            _passwordHashService = new PasswordHashService(_options);
        }

        [Theory]
        [InlineData(_password)]
        public async Task PasswordHashService_Generate_returnToken(string password)
        {
            var result = _passwordHashService.Generate(password);

            result.Should().NotBeNull();
            result.Should().BeOfType<string>();
            result.Should().ContainAny(";");
        }

        [Theory]
        [InlineData(_password, _hashPassword)]
        public async Task PasswordHashService_Validate_returnTrue(string password, string passwordHash)
        {

            var result = _passwordHashService.Validate(password, passwordHash);

            result.Should().BeTrue();

        }
    }
}
