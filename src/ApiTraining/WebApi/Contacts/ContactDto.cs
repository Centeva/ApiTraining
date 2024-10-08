﻿namespace ApiTraining.WebApi.Contacts;

public class ContactDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? EmailAddress { get; set; }
}
