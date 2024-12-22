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

        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public DbSet<SystemConfigurationHistory> SystemConfigurationsHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
