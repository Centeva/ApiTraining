using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    // Code common to all controllers can go here
}