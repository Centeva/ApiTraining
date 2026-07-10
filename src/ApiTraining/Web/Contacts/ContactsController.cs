using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Web.Contacts;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(ILogger<ContactsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContactDto>> GetContact(Guid id)
    {
        _logger.LogInformation("Getting contact with ID {Id}", id);

        // TODO: Actually get the contact from the database
        var contact = new ContactDto
        {
            Id = Guid.Empty,
            FirstName = string.Empty,
            LastName = string.Empty,
            BirthDate = null,
            EmailAddress = null
        };

        return contact;
    }
}
