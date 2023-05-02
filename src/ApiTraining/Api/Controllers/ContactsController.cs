using ApiTraining.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ApiControllerBase
{
    private readonly ILogger<ContactsController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public ContactsController(ILogger<ContactsController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }


}
