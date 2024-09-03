global using PitStopAuctions.Client.Services.UserService;
global using PitStopAuctions.Client.Services.MarcaService;
global using PitStopAuctions.Client.Services.LeilaoService;
global using PitStopAuctions.Client.Services.LanceService;

global using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PitStopAuctions.Client;
using PitStopAuctions.Client.Services.LanceService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILeilaoService, LeilaoService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();
builder.Services.AddScoped<ILanceService, LanceService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
