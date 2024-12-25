using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalWebApps.WebApp.Data.Models;
using PortalWebApps.WebApp.Database;
using PortalWebApps.WebApp.Models.Utils;

namespace PortalWebApps.WebApp.Controllers
{
    [Authorize]
    public class ConfigurationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly CookiesAccess _cookies;
        private const int pageSize = 10;
        public ConfigurationController(AppDbContext context, IConfiguration configuration, CookiesAccess cookies)
        {
            _context = context;
            _configuration = configuration;
            _cookies = cookies;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.SystemSettings.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection fc)
        {
            var usuario = _context.Users.FirstOrDefault(x => x.Id == _cookies.UserId)!;

            string[] idSystemSettings = fc["Id"].ToString().Split(',');

            for (int i = 0; i < idSystemSettings.Length; i++)
            {
                var systemSetting = _context.SystemSettings.Find(int.Parse(idSystemSettings[i]))!;

                string oldValue = systemSetting.Value;
                string newValue = fc["ConfigValue_" + idSystemSettings[i]].ToString();

                if (newValue.ToUpper() == "TRUE")
                {
                    systemSetting.Value = "True";
                    systemSetting.Status = true;
                }
                else if (newValue.ToUpper() == "FALSE")
                {
                    systemSetting.Value = "False";
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
                    SystemSettingHistory history = new SystemSettingHistory();
                    history.Name = systemSetting.Name;
                    history.OldValue = oldValue;
                    history.NewValue = systemSetting.Value;
                    history.ChangedBy = usuario!.Id;
                    history.ChangeDate = DateTime.Now;

                    _context.SystemSettingsHistory.Add(history);
                    _context.SaveChanges();
                }
            }

            return View(_context.SystemSettings.ToList());
        }

        [HttpGet]
        public IActionResult SystemSettingsHistory(string fieldName, string startDate, string endDate, int page = 1)
        {
            var systemSettingsHistory = _context.SystemSettingsHistory.OrderByDescending(x => x.ChangeDate).ToList();
            var users = _context.Users.ToList();

            try
            {
                DateTime? startDateValue = DateTime.TryParse(startDate, out DateTime outStartDateValue) ? outStartDateValue : null;
                DateTime? endDateValue = DateTime.TryParse(endDate, out DateTime outEndDateValue) ? outEndDateValue : null;

                if (!string.IsNullOrEmpty(fieldName))
                    systemSettingsHistory = systemSettingsHistory.Where(x => x.Name.Contains(fieldName)).ToList();

                if(startDateValue.HasValue && endDateValue.HasValue)
                {
                    systemSettingsHistory = systemSettingsHistory
                        .Where(x => x.ChangeDate.Date >= startDateValue && x.ChangeDate <= endDateValue).ToList();
                }
                else if(startDateValue.HasValue && !endDateValue.HasValue)
                {
                    systemSettingsHistory = systemSettingsHistory
                        .Where(x => x.ChangeDate.Date >= startDateValue).ToList();
                }
                else if(!startDateValue.HasValue && endDateValue.HasValue)
                {
                    systemSettingsHistory = systemSettingsHistory
                        .Where(x => x.ChangeDate <= endDateValue).ToList();
                }

                // Apply users on item
                foreach (var item in  systemSettingsHistory)
                {
                    var user = users.FirstOrDefault(x => x.Id == item.ChangedBy);

                    if (user == null)
                        continue;

                    item.User = user;
                }

                ViewBag.Page = page;
                ViewBag.TotalPages = Math.Ceiling((decimal)systemSettingsHistory.Count / pageSize);
                ViewBag.Name = fieldName ?? string.Empty;
                ViewBag.StartDate = startDateValue;
                ViewBag.EndDate = endDateValue;
            }
            catch(Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["Status"] = "danger";
            }

            return View(systemSettingsHistory.Skip((page - 1) * pageSize).Take(pageSize));
        }
    }
}
