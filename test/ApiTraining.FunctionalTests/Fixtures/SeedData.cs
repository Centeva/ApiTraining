using ApiTraining.Domain.Entities;
using ApiTraining.Infrastructure.Data;

namespace ApiTraining.FunctionalTests.Fixtures;

internal static class SeedData
{
    // Put seed data instances here

    public static readonly Contact Contact1 = new(Guid.NewGuid(), "Joe", "Test")
        { BirthDate = new DateTime(1980, 1, 1), EmailAddress = "test@example.com" };

    public static void PopulateTestData(ApplicationDbContext dbContext)
    {
        // Remove existing entities
        foreach (var item in dbContext.Contacts)
        {
            dbContext.Remove(item);
        }

        dbContext.SaveChanges();

        dbContext.Contacts.Add(Contact1);

        dbContext.SaveChanges();
    }
}