using HostbeatWeb.Services.Results;

namespace HostbeatWeb.Services.Interfaces;

public interface IHostbeatApiService
{
    Task<ConfirmEmailResult> ConfirmEmail(string email, string token);
}