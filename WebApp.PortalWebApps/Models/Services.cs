using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using PortalWebApps.WebApp.Data.Models;
using System.Security.Claims;
using PortalWebApps.WebApp.Models.Utils;

namespace PortalWebApps.WebApp.Models
{
    public class Services
    {
        public async Task SignIn(HttpContext ctx, User usuario)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim("UserId", usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Name, usuario.Name),
            new Claim(ClaimTypes.Role, Enums.GetProfileName(usuario.Profile))
        };

            var claimIdentity = new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(1),
                IssuedUtc = DateTime.Now,
                IsPersistent = true
            };

            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimIdentity, authProperties);
        }

        public async Task SignOut(HttpContext ctx)
        {
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
