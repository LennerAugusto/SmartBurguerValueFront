using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SmartBurguerValueAdmin;
using SmartBurguerValueFront.Services;
using SmartBurguerValueRCL.Services;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<DialogService>();

builder.Services.AddBlazoredToast();

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

var apiUrl = builder.Configuration["UrlApi"];

builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<CustomAuthorizationMessageHandler>();
    handler.InnerHandler = new HttpClientHandler(); 
    return new HttpClient(handler)
    {
        BaseAddress = new Uri(apiUrl)
    };
});

await builder.Build().RunAsync();
