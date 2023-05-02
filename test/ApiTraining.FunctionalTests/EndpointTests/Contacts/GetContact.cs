using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTraining.FunctionalTests.Fixtures;
using Ardalis.HttpClientTestExtensions;
using FluentAssertions;

namespace ApiTraining.FunctionalTests.EndpointTests.Contacts
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

            await _client.GetAndEnsureNotFoundAsync($"api/contacts/{badId}");
        }

        [Fact]
        public async Task WhenFound_ReturnsDetails()
        {
            var result = await _client.GetAndDeserializeAsync<ContactResult>($"api/contacts/{SeedData.Contact1.Id}");

            result.Should().NotBeNull();
            result.Id.Should().Be(SeedData.Contact1.Id);
            result.FirstName.Should().Be(SeedData.Contact1.FirstName);
            result.LastName.Should().Be(SeedData.Contact1.LastName);
            result.BirthDate.Should().Be(SeedData.Contact1.BirthDate);
        }
    }


    internal class ContactResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
