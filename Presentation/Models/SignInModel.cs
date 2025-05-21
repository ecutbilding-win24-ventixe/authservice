using System.Text.Json.Serialization;

namespace Presentation.Models;

public class SignInModel
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}
