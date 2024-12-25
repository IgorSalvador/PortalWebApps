using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalWebApps.WebApp.Data.Models;
using PortalWebApps.WebApp.Database;
using PortalWebApps.WebApp.Models.Utils;
using PortalWebApps.WebApp.Models.ViewModels;

namespace PortalWebApps.WebApp.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly CookiesAccess _cookies;
        private const int pageSize = 10;

        public ApplicationController(AppDbContext context, IConfiguration configuration, CookiesAccess cookies)
        {
            _context = context;
            _configuration = configuration;
            _cookies = cookies;
        }

        [HttpGet]
        public IActionResult Index(string applicationName, string status, int page = 1)
        {
            var applications = _context.Applications.ToList();

            try
            {
                if(!string.IsNullOrEmpty(applicationName))
                    applications = applications.Where(x => x.Name.Contains(applicationName)).ToList();

                if (!string.IsNullOrEmpty(status))
                {
                    bool statusValue = status == "1" ? true : false;
                    applications = applications.Where(x => x.Status == statusValue).ToList();
                }

                ViewBag.Page = page;
                ViewBag.TotalPages = Math.Ceiling((decimal)applications.Count / pageSize);
                ViewBag.Name = applicationName ?? string.Empty;
                ViewBag.Status = status ?? string.Empty;
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["Status"] = "danger";
            }

            return View(applications.Skip((page - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ApplicationViewModel());
        }
    }
}
