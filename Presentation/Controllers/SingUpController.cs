using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SingUpController : ControllerBase
{
    [HttpPost]
    public IActionResult SingUp(SignUpModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

       

    }
}
