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
        public const string _passwordHash = "0qcVx8uFFSm1VMlrFfYd0g==;lINnHFdzZYWdKcn9cCgnIfwSgh8UmPj9fF6UmDjY1Pk=";
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

        [Fact]
        public async Task PasswordHashService_Generate_ReturnToken()
        {
            var result = _passwordHashService.Generate(_password);

            result.Should().NotBeNull();
            result.Should().BeOfType<string>();
            result.Should().ContainAny(";");
        }

        [Fact]
        public async Task PasswordHashService_Validate_ReturnTrue()
        {

            var result = _passwordHashService.Validate(_password, _passwordHash);

            result.Should().BeTrue();

        }
    }
}
