using Presentation.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Presentation.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://ventixe-accountservice-dwdudheubmdnczct.swedencentral-01.azurewebsites.net/");
    }

    public async Task<AccountServiceResult> SignUp(SignUpModel model)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/signup", model);

            if (!response.IsSuccessStatusCode)
                return new AccountServiceResult { Succeeded = false, StatusCode = (int)response.StatusCode, Message = "Failed to create account" };

            var result = await response.Content.ReadFromJsonAsync<AccountServiceResult>();
            return result ?? new AccountServiceResult { Succeeded = false, StatusCode = 500, Message = "Failed to parse response" };
        }
        catch (Exception ex)
        {
            return new AccountServiceResult { Succeeded = false, StatusCode = 500, Message = $"Server error: {ex.Message}" };
        }
    }

    public async Task<SignInResult> SingInAsync(SignInModel model)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/signin", model);
            if (!response.IsSuccessStatusCode)
                return new SignInResult { Succeeded = false, StatusCode = (int)response.StatusCode, Message = "Failed to sign in" };


           var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            return new SignInResult
            {
                Succeeded = json.GetProperty("succeeded").GetBoolean(),
                StatusCode = 200,
                Message = json.GetProperty("message").GetString(),
                Token = json.GetProperty("token").GetString(),
                Email = json.GetProperty("email").GetString(),
                UserId = json.GetProperty("userId").GetString()
            };
        }
        catch (Exception ex)
        {
            return new SignInResult { Succeeded = false, StatusCode = 500, Message = $"Server error: {ex.Message}" };
        }
    }
}
