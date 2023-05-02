using Microsoft.AspNetCore.Mvc;

namespace ApiTraining.Api.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    // Code common to all controllers can go here
}