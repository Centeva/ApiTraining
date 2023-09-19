using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Api.Controllers;

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
        return Ok();
    }
}
