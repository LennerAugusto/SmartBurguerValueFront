//using Blazored.Toast;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Radzen;
//using SmartBurguerValueFront;
//using SmartBurguerValueFront.Services;
//using SmartBurguerValueRCL.Services;
//using System.Net.Http.Headers;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");

//// Serviços Radzen
//builder.Services.AddScoped<Radzen.DialogService>();
//builder.Services.AddScoped<DialogService>();
//builder.Services.AddScoped<TooltipService>();

//// Toast
//builder.Services.AddBlazoredToast();

//// Autenticação
//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<CustomAuthStateProvider>();
//builder.Services.AddScoped<AuthService>();

//// Handler para adicionar token
//builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

//// URL da API
//var apiUrl = builder.Configuration["UrlApi"];

//// HttpClient injetável com handler
//builder.Services.AddScoped(sp =>
//{
//    var handler = sp.GetRequiredService<CustomAuthorizationMessageHandler>();
//    var client = new HttpClient(handler)
//    {
//        BaseAddress = new Uri(apiUrl)
//    };
//    return client;
//});

//await builder.Build().RunAsync();
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SmartBurguerValueFront;
using SmartBurguerValueFront.Services;
using SmartBurguerValueRCL.Services;
using System.Net.Http.Headers;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Adiciona os serviços Radzen
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<TooltipService>();

// Adiciona Blazored Toast
builder.Services.AddBlazoredToast();

// Adiciona a Autenticação e Autorização
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());

// Adiciona o handler para adicionar o token
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

// URL da API
var apiUrl = builder.Configuration["UrlApi"];
// Configura o HttpClient para usar o handler
builder.Services.AddScoped<HttpClient>(sp =>
{
    var handler = sp.GetRequiredService<CustomAuthorizationMessageHandler>();
    return new HttpClient(handler)
    {
        BaseAddress = new Uri(apiUrl)
    };
});


await builder.Build().RunAsync();