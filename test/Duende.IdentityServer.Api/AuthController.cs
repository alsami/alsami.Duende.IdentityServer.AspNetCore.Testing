using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Duende.IdentityServer.Api;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult TestAuth()
    {
        return new OkObjectResult(new
        {
            Message = "This endpoint would not be reachable, if the authentication was not working"
        });
    }
}