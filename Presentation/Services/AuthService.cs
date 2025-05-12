using Presentation.Models;
using System.Reflection;

namespace Presentation.Services;

public class AuthService
{

    public async Task<bool> AlreadyExistsAsync(string email)
    {
        using var http = new HttpClient();
        var response = await http.GetFromJsonAsync<AccountServiceResult>($"https://localhost:7274/api/accounts?email={email}").Result;
        return response.Succeeded;
    }

    public async Task<AuthServiceResult> SignUp(SignUpModel model)
    {
        var exists = await AlreadyExistsAsync(model.Email);
        if (!exists)
        {
            return null;
        }

        using var http = new HttpClient();
        var response = http.PostAsJsonAsync("https://localhost:7274/api/accounts", model).Result;
    }
}
