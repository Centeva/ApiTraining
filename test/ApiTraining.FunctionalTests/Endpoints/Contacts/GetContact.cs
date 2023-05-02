using ApiTraining.FunctionalTests.Fixtures;
using Ardalis.HttpClientTestExtensions;
using FluentAssertions;

namespace ApiTraining.FunctionalTests.Endpoints.Contacts
{
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

            await _client.GetAndEnsureNotFoundAsync($"contacts/{badId}");
        }

        [Fact]
        public async Task WhenFound_ReturnsDetails()
        {
            var result = await _client.GetAndDeserializeAsync<ContactResult>($"contacts/{SeedData.Contact1.Id}");

            result.Should().NotBeNull();
            result.Id.Should().Be(SeedData.Contact1.Id);
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? EmailAddress { get; set; }
    }
}
