using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Ant.Todo.Tests.Integration.Swagger
{
    public class SwaggerTests : IntegrationTestBase
    {
        public SwaggerTests(IntegrationTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async void ShouldReturnOk_WhenSwaggerDocsWorks()
        {
            // Arrange

            // Act
            var result = await Client.GetAsync("swagger/v1/swagger.json");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}