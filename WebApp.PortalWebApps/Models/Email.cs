using PortalWebApps.WebApp.Database;

namespace PortalWebApps.WebApp.Models
{
    public class Email
    {
        private readonly AppDbContext _context;

        public Email(AppDbContext context)
        {
            _context = context; 
        }
    }
}
