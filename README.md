# Asp.NET Core Web API Exercise

This is a small coding exercise involving a simple Web API.  It is intended to
be used for training purposes and for technical interviews.

After reading through this introduction, see
[docs/Exercises.md](docs/Exercises.md) for some programming tasks to complete.

## Technologies

- [ASP.NET
  Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-10.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) -
  persistence of application data.  This code uses SQLite as the data store to
  avoid the need for running extra services.
- [AwesomeAssertions](https://awesomeassertions.org/) - extension methods for
  better .NET test readability
- [AwesomeAssertions.Web](https://github.com/adrianiftode/FluentAssertions.Web) - assertion
  extension methods for AwesomeAssertions for inspecting HTTP responses

## Project Structure

This is a standard ASP.NET Core Web API application, but with three "layers" to
separate concerns.  A real project would probably put these layers into separate
.NET projects, but for this exercise they are all in the same project.

### `Domain` Folder

This contains the "domain model" for the application and defines the business
objects.  Each module (only one, Contacts, so far) has its own folder under
`Domain`, with shared code in a `Common` folder.  The `Domain` folder is
intended to be the most stable part of the application, and should not change
much over time.  It should not reference any other part of the application code.

### `Web` Folder

This contains the controllers and other code that is HTTP-specific.  It
references classes in the `Domain` folder, but nothing else.  Each "feature" or
section of the API has its own folder which contains the controller(s) and any
other code specific to that feature.

### `Infrastructure` Folder

This contains code that is specific to the infrastructure of the application.
This includes things like database access, logging, and other things that are
not specific to the Web API.  For example, it contains the configuration for
Entity Framework Core, which is used to access the database.

## Setup

No external services are needed to run this code.  As you build on top of it to
add features, this will likely change.

### Database Migrations

The `dotnet-ef` tool is used to create and run database migrations.  Restore the
required tools with:

```sh
dotnet tool restore
```

To get started and create the database, use a terminal or the Visual Studio
Package Manager Console to run this command from the root of this repository:

```sh
dotnet ef database update --project src/ApiTraining
```

**IF** you need to add a new migration later, run this command from the root of
this repository:

```sh
dotnet ef migrations add [NewMigrationName] --project src/ApiTraining
```

After creating a new migration, run the `database update` command above to
refresh your database.

## Running the Application

Run the application in debug mode, which should open your browser to the
SwaggerUI interface, from the usual Visual Studio debug command.

You can also open the ApiTraining.http file in Visual Studio and run the
requests from there.

A contact with the ID "019f42ee-b3e4-769e-b10c-449a47879567" has been seeded
into the database - you can use it for manual testing.

## Running Tests

Run tests from the Visual Studio Test Explorer (or the Test menu) or run `dotnet
test` in your terminal.

