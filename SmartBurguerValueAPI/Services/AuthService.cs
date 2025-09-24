using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using SmartBurguerValueFront.Requests;
using SmartBurguerValueFront.Responses;

namespace SmartBurguerValueFront.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly NavigationManager _nav;
        private readonly CustomAuthStateProvider _authProvider;

        public AuthService(HttpClient http, IJSRuntime js, NavigationManager nav, CustomAuthStateProvider authProvider)
        {
            _http = http;
            _js = js;
            _nav = nav;
            _authProvider = authProvider;
        }

        public async Task<bool> Login(LoginRequest login)
        {
            var response = await _http.PostAsJsonAsync("Auth/login", login);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            // Salva o token no localStorage
            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", result.Token);

            // Notifica o provedor de autenticação que o usuário foi autenticado
            _authProvider.NotifyUserAuthentication(result.Token);

            // Navega para a página inicial
            _nav.NavigateTo("/");
            return true;
        }

        public async Task Logout()
        {
            // Remove o token do localStorage
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");

            // Notifica o provedor de autenticação que o usuário fez logout
            _authProvider.NotifyUserLogout();

            // Navega para a página de login
            _nav.NavigateTo("/login");
        }
    }
}
