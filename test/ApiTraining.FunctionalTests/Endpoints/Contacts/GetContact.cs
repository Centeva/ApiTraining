using System.Text.Json;
using ApiTraining.FunctionalTests.Fixtures;
using Ardalis.HttpClientTestExtensions;

namespace ApiTraining.FunctionalTests.Endpoints.Contacts;

public class GetContact : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions;

    public GetContact(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
        // Match the default serializer for Asp.Net
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    [Fact]
    public async Task WhenNotFound_Produces404()
    {
        var badId = Guid.NewGuid();

        await _client.GetAndEnsureNotFoundAsync($"contacts/{badId}");
    }

    [Fact]
    public async Task WhenFound_ReturnsDetails()
    {
        var response = await _client.GetAsync($"contacts/{SeedData.Contact1.Id}");

        response.EnsureSuccessStatusCode();

        var stringResponse = await response.Content.ReadAsStringAsync();
        stringResponse.Should().NotBeNullOrEmpty();

        var result = JsonSerializer.Deserialize<ContactResult>(stringResponse, _jsonOptions);

        result.Should().NotBeNull();
        result!.Id.Should().Be(SeedData.Contact1.Id);
        result.FirstName.Should().Be(SeedData.Contact1.FirstName);
        result.LastName.Should().Be(SeedData.Contact1.LastName);
        result.BirthDate.Should().Be(SeedData.Contact1.BirthDate);
        result.EmailAddress.Should().Be(SeedData.Contact1.EmailAddress);
    }
}


/// <summary>
/// Placeholder for API results.  You may end up moving this to the application code later, in
/// which case reference that in the tests above.
/// </summary>
internal class ContactResult
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string? EmailAddress { get; set; }
}