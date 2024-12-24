using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortalWebApps.WebApp.Controllers
{
    public class ApplicationController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
