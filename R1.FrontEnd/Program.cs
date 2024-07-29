using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;

using Blazored.LocalStorage;
using MudBlazor.Services;
using R1.FrontEnd.WA.Services.Implementations;
using R1.FrontEnd.WA.Services.Interfaces;
using R1.FrontEnd.WA.Static;
using R1.FrontEnd.WA.Configurations;
using R1.FrontEnd.WA.Providers;
using R1.FrontEnd.WA;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddHttpClient("R1Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7224/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

//builder.Services.AddHttpClient("TempalteApi", sp => new HttpClient { BaseAddress = new Uri("https://localhost:7224") });

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("R1Api"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();



builder.Services.AddHttpClient<ISessionLapTimeService, SessionLapTimeService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
StaticDescriptions.SessionLapTimeAPIBase = "https://localhost:7224";
StaticDescriptions.AuthAPIBase = "https://localhost:7224";
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISessionLapTimeService, SessionLapTimeService>();
builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddAutoMapper(typeof(MapperConfig));


builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});


await builder.Build().RunAsync();
