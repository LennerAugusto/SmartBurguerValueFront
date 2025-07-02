using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static SmartBurguerValueFront.Pages.Login;
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

            if (!response.IsSuccessStatusCode) return false;

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", result.Token);
            _authProvider.NotifyUserAuthentication(result.Token);

            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);

            _nav.NavigateTo("/");
            return true;
        }

        public async Task Logout()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");
            _authProvider.NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;

            _nav.NavigateTo("/login");
        }
    }
}
