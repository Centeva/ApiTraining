using ApiTraining.Domain.Primitives;

namespace ApiTraining.Domain.Entities;

public class Contact : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Contact(Guid id) : base(id)
    {
    }
}