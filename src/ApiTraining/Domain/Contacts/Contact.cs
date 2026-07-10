using ApiTraining.Domain.Common;

namespace ApiTraining.Domain.Contacts;

public class Contact : Entity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly? BirthDate { get; set; }
    public string? EmailAddress { get; set; }

    public Contact(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Reserved for EF Core
    private Contact() { }
}
