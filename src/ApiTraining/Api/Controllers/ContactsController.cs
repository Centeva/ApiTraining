using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Api.Controllers;

public class ContactsController : ApiControllerBase
{
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(ILogger<ContactsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetContact(Guid id)
    {
        return Ok();
    }
}
