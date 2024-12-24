using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PortalWebApps.WebApp.Data.Models;

namespace PortalWebApps.WebApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<SystemSettingHistory> SystemSettingsHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
