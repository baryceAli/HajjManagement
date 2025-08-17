using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HajjManagement.Shared.Utilities
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public CustomAuthStateProvider()
        {
            
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            if (!string.IsNullOrWhiteSpace(GlobalData.Token))
            {
                var claims = ParseClaimsFromJwt(GlobalData.Token);
                identity = new ClaimsIdentity(claims, "jwt");
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public void NotifyUserAuthentication(string token)
        {
            GlobalData.Token = token; // Keep token in global state

            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            GlobalData.Token = null;

            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var claims = token.Claims.ToList();

            // Ensure roles are properly mapped
            claims.AddRange(token.Claims
                .Where(c => c.Type == "role")
                .Select(r => new Claim(ClaimTypes.Role, r.Value)));

            return claims;
        }
    }
}
