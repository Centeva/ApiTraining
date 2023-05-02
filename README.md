# Asp.NET Core Web API Exercise

This is a small coding exercise involving a simple Web API.  It is intended to
be used for training purposes and for technical interviews.

## Technologies

- [ASP.NET
  Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) -
  persistence of application data.  This code uses SQLite as the data store to
  avoid the need for running extra services.
- [FluentValidation](https://docs.fluentvalidation.net/) - specify .NET API
  model validation rules
- [Fluent Assertions](https://fluentassertions.com/) - extension methods for
  better .NET test readability

## Setup

No external services are needed to run this code.  As you build on top of it to
add features, this will likely change.

For Centeva team members, you may add a reference to the internal Centeva NuGet
repository to gain access to our own packages.  Contact a team member for
instructions.  (They're not included here because this is a public repository.)

### Database Migrations

The `dotnet-ef` tool is used to create and run database migrations.  Restore the
required tools with:

```sh
dotnet tool restore
```

To create/update your database by applying missing migrations, run this command
from the root of this repository:

```sh
dotnet tool run dotnet-ef database update --project src/ApiTraining
```

To add a new migration, run this command from the root of this repository:

```sh
dotnet tool run dotnet-ef migrations add "Initial" --project src/ApiTraining
```

## Running the Application

Run the application in debug mode, which should open your browser to the
SwaggerUI interface, from the usual Visual Studio debug command.

## Running Tests

Run tests from the Visual Studio Test Explorer (or the Test menu) or run `dotnet
test` in your terminal.

## Next Steps

See [docs/Exercises.md](docs/Exercises.md) for tasks to complete.
