# Training Exercises

1. Ensure that the database is created, and that the application builds and
   runs.  You should see an API browser interface in your browser upon
   successful startup.  (You can use this interface to manually test your work.)

2. Run the test suite.  You should get failing tests.

3. Implement the API endpoint to get the existing tests to pass.

4. Implement a new API endpoint for creation of a Contact.  Include new
   functional tests as well that verify these requirements:

   * The endpoint should receive `POST` requests to `/contacts`, with the
     contact detail as JSON in the request body.
   * The request body should accept FirstName, LastName, BirthDate, and
     EmailAddress properties:
   * The new Contact should be persisted to the database.
   * Use an appropriate HTTP status code, headers, and response body (if
     any), and be able to explain your choices.

## Additional Tasks

Below are some additional exercises you can perform for training or
demonstration purposes.  You can do these in any order, although they are
generally ordered least to most complex.

1. Add data validation to the Contact creation endpoint.  Ensure that all
   properties of the Contact are provided, with the following additional rules:

   * First and Last Names are required, with a maximum length of 50 characters
   * BirthDate, if provided, should be in the past
   * EmailAddress, if provided, should be in a valid format

   Invalid requests should not result in creation of a Contact, and should
   produce the appropriate HTTP status code, ideally with information about the
   nature of the failure.  Be able to explain the validation approach you chose
   and any trade-offs it involves.

2. Data integrity is crucial in important business applications.  Update the
   Contact class to enforce the rules at the domain level.  (This is called
   enforcing invariants.) Assume that that the validation requirements above
   cannot be circumvented at any point.  

   Write unit tests as needed to provided an executable specification of new
   behavior.

   Be able to explain why you would want to enforce these rules at the domain
   level, and not just at the API (HTTP) level.  What would happen to data
   integrity if a different kind of client needed to create or modify Contacts
   without going through this Web API?

3. Create a new API endpoint for modification of a Contact.  Continue to ensure
   data integrity as described above.

   * Use the appropriate HTTP method and URL format for REST-style APIs.
   * Produce an appropriate HTTP response code when successful
   * Handle the case when the Contact with the specified ID does not exist
   * Handle the case when the provided information is invalid
   * Write functional tests to specify these scenarios
   * Be able to explain your choice of HTTP method, and how it affects the
     semantics of the request (for example, idempotency, or partial versus full
     updates)
  
4. Create a new API endpoint for deletion of a Contact.  Continue to ensure data
   integrity.

   * Use the appropriate HTTP method and URL format for REST-style APIs.
   * Produce an appropriate HTTP response code when successful
   * Handle the case when the Contact with the specified ID does not exist
   * Write functional tests to specify possible scenarios
   * Be able to explain what should happen if the same delete request is sent
     more than once

5. Implement the following business rule, with appropriate validation:

   Contacts can have one or more Addresses.  Each Address has the following
   properties, all of which are required:

   * Street
   * City
   * State Code
   * Postal Code

   Ensure that Entity Framework is properly configured to persist instances of
   Address.

   Questions to explore:

   * Should a Contact's addresses be returned as part of the GET /contacts/{id}
     API endpoint?  What are the tradeoffs of including or not including them?
   * Can an Address exist independently of a Contact?  
   * What data type is best to use to represent a Contact's collection of
     Addresses?

6. Create additional API endpoints for creation and retrieval of Addresses:

   * Create a new Address for a Contact
   * Get a list of a Contact's Addresses
   * Remove an Address from a Contact
   * Use appropriate HTTP status codes and response headers/body for each
   * Write functional tests for all possible scenarios
   * Be able to explain your URL design choices for these nested resources

7. Explain the concept of "primitive obsession."

   * How does the codebase exhibit this anti-pattern?
   * How would you refactor the code to avoid it?
   * Can you refactor without breaking the existing API or database schema?

8. Data access logic (via Entity Framework's `DbContext`) may currently be used
   directly within your Controllers or request handlers.

   Questions to explore:

   * What options do you have for abstracting or encapsulating data access
     logic, and how would each one work?
   * Is `DbContext` already an abstraction over data access in its own right
     (for example, Unit of Work, with `DbSet<T>` acting like a repository)?
     What, if anything, would introducing a separate Repository pattern add on
     top of that?
   * What are the trade-offs of a Repository pattern compared to other
     approaches, such as using `DbContext` directly, or something else entirely?
   * How would you decide whether the added abstraction is worth it for a given
     project?

9. Take a look at `ContactsController`. Imagine the team asks you to add several
   more responsibilities before a Contact is saved, such as input validation, an
   audit log entry, and a notification email. Now imagine a different kind of
   client, such as a background job, a message queue consumer, or a command-line
   tool, also needs to execute that same business logic without going through
   the Web API at all.

   Questions to explore:

   * How would you evolve the design to keep the controller focused as its
     responsibilities grow, and to make the underlying logic reusable across
     different kinds of clients?
   * Walk through the pieces you would introduce and how they would interact.
   * What are the trade-offs of the approach you are describing?
   * At what point (team size, project size, complexity) would you actually
     introduce this kind of structure, versus keeping things simple?

10. This API currently defines its endpoints using MVC controllers.

    Questions to explore:

    * What other approaches does ASP.NET Core support for defining HTTP
      endpoints, and how do they compare to what is used here?
    * If you had to sketch `GetContact` using an alternative approach, what
      would that look like?
    * What would change about how the project is organized as the number of
      endpoints grows?
    * Would you recommend switching this project to a different approach? Why or
      why not?

11. Suppose the team wants to enforce some of the boundaries you've discussed in
    the previous three questions (data access, business logic reuse, and
    endpoint definitions) so they can't be accidentally violated later, even as
    more engineers join the team.

    Questions to explore:

    * Besides code review and convention, what mechanisms are available in .NET
      to enforce a dependency direction between layers?
    * When would you introduce separate projects (or assemblies) to enforce
      this, and what would each one be allowed (or not allowed) to reference?
    * What does that cost you (build time, ceremony, versioning, and onboarding)
      compared to keeping everything in one project, as this solution does
      today?
    * At what point does that cost become worth paying?
