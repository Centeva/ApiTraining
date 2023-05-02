using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ApiControllerBase
{
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(ILogger<ContactsController> logger)
    {
        _logger = logger;
    }
}
