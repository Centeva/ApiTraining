using ApiTraining.Domain.Contacts;

namespace ApiTraining.UnitTests.Domain.Contacts;

public class ContactTests
{
    [Fact]
    public void Constructor_SetsFirstAndLastName()
    {
        const string firstName = "John";
        const string lastName = "Doe";

        var contact = new Contact(firstName, lastName);

        contact.FirstName.Should().Be(firstName);
        contact.LastName.Should().Be(lastName);
    }

    [Fact]
    public void Constructor_AssignsNonDefaultId()
    {
        var contact = new Contact("John", "Doe");

        contact.Id.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Constructor_DoesNotSetOptionalProperties()
    {
        var contact = new Contact("John", "Doe");

        contact.BirthDate.Should().BeNull();
        contact.EmailAddress.Should().BeNull();
    }

    [Fact]
    public void BirthDate_CanBeSet()
    {
        var contact = new Contact("John", "Doe");
        var birthDate = new DateOnly(1990, 1, 1);

        contact.BirthDate = birthDate;

        contact.BirthDate.Should().Be(birthDate);
    }

    [Fact]
    public void EmailAddress_CanBeSet()
    {
        var contact = new Contact("John", "Doe");
        const string email = "john.doe@example.com";

        contact.EmailAddress = email;

        contact.EmailAddress.Should().Be(email);
    }

    [Theory]
    [InlineData("Jane", "Smith")]
    [InlineData("", "")]
    public void FirstAndLastName_CanBeUpdated(string newFirstName, string newLastName)
    {
        var contact = new Contact("John", "Doe");

        contact.FirstName = newFirstName;
        contact.LastName = newLastName;

        contact.FirstName.Should().Be(newFirstName);
        contact.LastName.Should().Be(newLastName);
    }
}
