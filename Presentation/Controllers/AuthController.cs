using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;

    [HttpPost("signup")]
    public async Task<IActionResult> SingUp([FromBody] SignUpModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.SignUp(model);

        if (result == null || !result.Succeeded)
            return BadRequest(new { message = result?.Message ?? "Failed to create account" });

        return Ok(new { message = "Account created successfully" });
    }
}
