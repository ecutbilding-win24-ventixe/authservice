namespace Presentation.Models;

public class SignInResult : AccountServiceResult
{
    public string? Token { get; set; }
    public string? Email { get; set; }
}