using System.Text;
using System.Text.Json;
using HostbeatWeb.Services.Interfaces;
using HostbeatWeb.Services.Results;

namespace HostbeatWeb.Services;

public enum ResultErrorCodes
{
    Unknown = -1,
}

public class Result
{
    public required bool Success { get; set; }
    public int? FailureCode { get; set; }
}

public class HostbeatApiService(ILogger<HostbeatApiService> logger, HttpClient httpClient) : IHostbeatApiService
{
    private const string JsonMediaType = "application/json";
    
    public async Task<ConfirmEmailResult> ConfirmEmail(string email, string token)
    {
        logger.LogInformation($"Confirming email for '{email}' with token ('{token}')");

        var request = new { email, token };
        var response = await httpClient.PostAsync("api/identity/confirm-email", GetJsonContent(request));

        return !response.IsSuccessStatusCode
            ? ConfirmEmailResult.Failure(response.StatusCode)
            : ConfirmEmailResult.Ok();
    }

    private StringContent GetJsonContent(object data)
    {
        string jsonString = JsonSerializer.Serialize(data);
        return new StringContent(jsonString, Encoding.UTF8, JsonMediaType);
    }
}