using Microsoft.AspNetCore.Mvc;
using PortalWebApps.WebApp.Data.Models;
using PortalWebApps.WebApp.Database;
using PortalWebApps.WebApp.Models.Utils;

namespace PortalWebApps.WebApp.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly CookiesAccess _cookies;

        public ConfigurationController(AppDbContext context, IConfiguration configuration, CookiesAccess cookies)
        {
            _context = context;
            _configuration = configuration;
            _cookies = cookies;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.SystemConfigurations.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection fc)
        {
            var usuario = _context.Users.FirstOrDefault(x => x.Id == _cookies.UserId)!;

            string[] idSystemSettings = fc["Id"].ToString().Split(',');

            for (int i = 0; i < idSystemSettings.Length; i++)
            {
                var systemSetting = _context.SystemConfigurations.Find(int.Parse(idSystemSettings[i]))!;

                string oldValue = systemSetting.Value;
                string newValue = fc["ConfigValue_" + idSystemSettings[i]].ToString();

                if (newValue == "True")
                {
                    systemSetting.Value = "S";
                    systemSetting.Status = true;
                }
                else if (newValue == "False")
                {
                    systemSetting.Value = "N";
                    systemSetting.Status = false;
                }
                else
                {
                    systemSetting.Value = newValue;
                    systemSetting.Status = string.IsNullOrEmpty(newValue);
                }

                if (systemSetting.Value != oldValue)
                {
                    //Gravar a alteração
                    _context.Entry(systemSetting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    //Gravar no Histórico
                    SystemConfigurationHistory history = new SystemConfigurationHistory();
                    history.Name = systemSetting.Name;
                    history.OldValue = oldValue;
                    history.NewValue = systemSetting.Value;
                    history.UserId = usuario!.Id;
                    history.ChangeDate = DateTime.Now;

                    _context.SystemConfigurationsHistory.Add(history);
                    _context.SaveChanges();
                }
            }

            return View(_context.SystemConfigurations.ToList());
        }
    }
}
