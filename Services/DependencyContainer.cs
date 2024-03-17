using HostbeatWeb.Configurations;
using HostbeatWeb.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace HostbeatWeb.Services;

public static class DependencyContainer
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpClient<IHostbeatApiService, HostbeatApiService>((provider, client) =>
        {
            var hostbeatBackendConfig = provider.GetRequiredService<IOptions<HostbeatBackendConfiguration>>().Value;
            client.Timeout = TimeSpan.FromSeconds(10);
            client.BaseAddress = new Uri(hostbeatBackendConfig.BaseUrl);
        });
    }
}