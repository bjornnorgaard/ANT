using Xunit;

namespace Api.Todos.Tests.Integration;

[Collection("IntegrationTests")]
public abstract class IntegrationTestBase : IDisposable
{
    public HttpClient Client { get; set; }

    /// <summary>
    /// This constructor is executed before each test.
    /// </summary>
    /// <param name="fixture"></param>
    public IntegrationTestBase(IntegrationTestFixture fixture)
    {
        Client = fixture.Client;
    }

    /// <summary>
    /// This Dispose() method is invoked after each test.
    /// </summary>
    public void Dispose()
    {
        // Clear database.
    }
}
