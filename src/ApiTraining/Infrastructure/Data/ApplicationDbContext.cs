using System.Reflection;

using ApiTraining.Core.Contacts;

using Microsoft.EntityFrameworkCore;

namespace ApiTraining.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contact> Contacts => Set<Contact>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
