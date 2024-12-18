using HostbeatWeb.Components;
using HostbeatWeb.Configurations;
using HostbeatWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder.Services.AddConfigurations();

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/api/health");
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
