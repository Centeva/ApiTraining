using ApiTraining.FunctionalTests.Fixtures;

namespace ApiTraining.FunctionalTests.Endpoints.Contacts;

public class GetContact : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public GetContact(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task WhenNotFound_Produces404()
    {
        var badId = Guid.NewGuid();

        var response = await _client.GetAsync($"contacts/{badId}", TestContext.Current.CancellationToken);

        response.Should().Be404NotFound();
    }

    [Fact]
    public async Task WhenFound_ReturnsDetails()
    {
        var response = await _client.GetAsync($"contacts/{SeedData.Contact1.Id}", TestContext.Current.CancellationToken);

        response.Should().Be200Ok().And.BeAs(new
        {
            Id = SeedData.Contact1.Id,
            FirstName = SeedData.Contact1.FirstName,
            LastName = SeedData.Contact1.LastName,
            BirthDate = SeedData.Contact1.BirthDate,
            EmailAddress = SeedData.Contact1.EmailAddress
        });
    }
}
