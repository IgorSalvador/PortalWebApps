using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalWebApps.WebApp.Data.Models;
using System.Reflection.Emit;

namespace PortalWebApps.WebApp.Data.Configurations
{
    public class SystemConfigurationConfiguration : IEntityTypeConfiguration<SystemConfiguration>
    {
        public void Configure(EntityTypeBuilder<SystemConfiguration> builder)
        {
            builder.ToTable("SystemConfigurations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
