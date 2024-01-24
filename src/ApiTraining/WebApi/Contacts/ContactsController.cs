using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.WebApi.Contacts;

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
    public IActionResult GetContact(Guid id)
    {
        _logger.LogInformation("Getting contact with ID {Id}", id);

        // TODO: Actually get the contact

        return Ok();
    }
}
