using ApiTraining.Core.Common;

namespace ApiTraining.Core.Contacts;

public class Contact : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? EmailAddress { get; set; }

    public Contact(Guid id, string firstName, string lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}