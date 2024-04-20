using Microsoft.Extensions.Options;

namespace HostbeatWeb.Configurations;

/// <summary>
/// Hostbeat backend configuration.
/// </summary>
public class HostbeatBackendConfiguration
{
    /// <summary>
    /// Gets or sets base Hostbeat HTTP API url.
    /// </summary>
    public required string BaseUrl { get; set; }
}

/// <summary>
/// Setup class to load Hostbeat backend configuration.
/// </summary>
/// <param name="config"></param>
public class HostbeatBackendConfigurationSetup(IConfiguration config) : IConfigureOptions<HostbeatBackendConfiguration>
{
    private const string SectionName = "HostbeatBackend";
    
    /// <summary>
    /// Method to configure Hostbeat configuration from main configuration.
    /// </summary>
    /// <param name="options">Instance to fill with configuration data.</param>
    public void Configure(HostbeatBackendConfiguration options)
    {
        config.GetSection(SectionName).Bind(options);
    }
}