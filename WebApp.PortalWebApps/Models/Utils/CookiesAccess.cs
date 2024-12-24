using Microsoft.EntityFrameworkCore;
using PortalWebApps.WebApp.Database;
using System.Security.Claims;

namespace PortalWebApps.WebApp.Models.Utils
{
    public class CookiesAccess
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsLoginExpired { get; set; }

        public CookiesAccess(AppDbContext db, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                var user = _httpContextAccessor.HttpContext.User;

                if (user.Identity.IsAuthenticated)
                {
                    ClaimsIdentity identity = (ClaimsIdentity)user.Identity; 
                    var claims = identity.Claims;

                    this.UserId = int.Parse(claims.Where(x => x.Type == "UserId").First().Value);
                    this.Name = claims.Where(x => x.Type == ClaimTypes.Name).First().Value;
                    this.Email = claims.Where(x => x.Type == ClaimTypes.Email).First().Value;
                    this.Role = claims.Where(x => x.Type == ClaimTypes.Role).First().Value;
                    this.IsLoggedIn = true;
                    this.IsLoginExpired = false;

                    _db.Database.GetDbConnection().Close();
                }
                else
                { 
                    throw new Exception("Usuário não autenticado."); 
                }
            }
            catch
            {
                this.UserId = 0;
                this.Name = string.Empty;
                this.Email = string.Empty;
                this.Role = string.Empty;
                this.IsLoggedIn = false;
                this.IsLoginExpired = true;
            }
        }
    }

    public static class CurrentCookies
    {
        public static int UserId { get; set; } = 0;
        public static string Name { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;
        public static bool IsLoggedIn { get; set; } = false;

        public static void GetCookies(CookiesAccess cookies)
        {
            cookies.Initialize();

            UserId = cookies.UserId;
            Name = cookies.Name;
            Email = cookies.Email;
            Role = cookies.Role;
            IsLoggedIn = cookies.IsLoggedIn;
        }
    }
}



