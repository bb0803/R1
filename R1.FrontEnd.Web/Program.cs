using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using R1.FrontEnd.Web;

using Blazored.LocalStorage;
using MudBlazor.Services;
using R1.FrontEnd.Web.Services.Implementations;
using R1.FrontEnd.Web.Services.Interfaces;
using R1.FrontEnd.Web.Static;
using R1.FrontEnd.Web.Configurations;
using R1.FrontEnd.Web.Providers;
using Microsoft.AspNetCore.Components.Authorization;

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


builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<ICarService, CarService>();
builder.Services.AddHttpClient<IDevelopmentService, DevelopmentService>();
builder.Services.AddHttpClient<IDriverService, DriverService>();
builder.Services.AddHttpClient<IResultService, ResultService>();
builder.Services.AddHttpClient<ISessionService, SessionService>();
builder.Services.AddHttpClient<ITeamService, TeamService>();
builder.Services.AddHttpClient<IUserService, UserService>();

StaticDescriptions.CarAPIBase = "https://localhost:7224";
StaticDescriptions.DevelopmentAPIBase = "https://localhost:7224";
StaticDescriptions.DriverAPIBase = "https://localhost:7224";
StaticDescriptions.ResultAPIBase = "https://localhost:7224";
StaticDescriptions.SessionAPIBase = "https://localhost:7224";
StaticDescriptions.TeamAPIBase = "https://localhost:7224";
StaticDescriptions.AuthAPIBase = "https://localhost:7224";

builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IDevelopmentService, DevelopmentService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();

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
