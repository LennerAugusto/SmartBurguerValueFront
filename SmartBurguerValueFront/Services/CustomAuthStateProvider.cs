using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _js;

    public CustomAuthStateProvider(IJSRuntime js)
    {
        _js = js;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        var identity = new ClaimsIdentity();

        if (!string.IsNullOrWhiteSpace(token))
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);

                if (jwt.ValidTo > DateTime.UtcNow)
                {
                    identity = new ClaimsIdentity(jwt.Claims, "jwt");
                }
            }
            catch
            {
                // token inválido
            }
        }

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public void NotifyUserAuthentication(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwt.Claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void NotifyUserLogout()
    {
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    public async Task<Guid?> GetEnterpriseId()
    {
        var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrWhiteSpace(token))
            return null;

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            if (jwt.ValidTo < DateTime.UtcNow)
                return null;

            var enterpriseIdClaim = jwt.Claims.FirstOrDefault(c => c.Type == "EnterpriseId")?.Value;

            if (Guid.TryParse(enterpriseIdClaim, out var enterpriseId))
                return enterpriseId;
            return null;
        }
        catch
        {
            return null;
        }
    }

}
