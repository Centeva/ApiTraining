﻿namespace ApiTraining.Api.Models;

public class ContactDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? EmailAddress { get; set; }
}
