namespace HostbeatWeb.Configurations;

public static class DependencyContainer
{
    public static void AddConfigurations(this IServiceCollection services)
    {
        services.ConfigureOptions<HostbeatBackendConfigurationSetup>();
    }
}