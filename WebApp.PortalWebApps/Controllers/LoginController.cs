using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalWebApps.WebApp.Database;
using PortalWebApps.WebApp.Models;
using PortalWebApps.WebApp.Models.GeneralModels;
using PortalWebApps.WebApp.Models.Utils;

namespace PortalWebApps.WebApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(LoginModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            string encryptedPassword = Utils.GetMD5Hash(login.Password);

            var usuario = _context.Users.FirstOrDefault(x => x.Email.ToUpper().Equals(login.Username.ToUpper())
                && x.Password.ToUpper().Equals(encryptedPassword.ToUpper()));

            if (usuario == null)
            {
                ViewData["Erro"] = "Usuário ou senha inválidos!";
                return View(login);
            }

            await new Services().SignIn(HttpContext, usuario);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await new Services().SignOut(HttpContext);

            return RedirectToAction(nameof(Index));
        }
    }
}
