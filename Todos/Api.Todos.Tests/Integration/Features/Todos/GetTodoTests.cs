﻿using System.Net;
using System.Net.Http.Json;
using Ant.Platform.Exceptions;
using Api.Todos.Controllers;
using Api.Todos.Features.Todos;
using FluentAssertions;
using Humanizer;
using Xunit;

namespace Api.Todos.Tests.Integration.Features.Todos;

public class GetTodoTests : IntegrationTestBase
{
    public GetTodoTests(IntegrationTestFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async void ShouldReturnBadRequest_WhenTodoDoesNotExist()
    {
        // Arrange
        var command = new GetTodo.Command { TodoId = Guid.NewGuid() };

        // Act
        var response = await Client.PostAsJsonAsync(Routes.Todos.GetTodo, command);
        var content = await response.Content.ReadFromJsonAsync<PlatformBadRequestResponse>();

        // Assert
        content.Code.Should().Be((int)PlatformError.TodoNotFound);
        content.Message.Should().Be(PlatformError.TodoNotFound.Humanize(LetterCasing.Sentence));
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
