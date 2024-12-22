using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalWebApps.WebApp.Data.Models;

namespace PortalWebApps.WebApp.Data.Configurations
{
    public class SystemConfigurationHistoryConfiguration : IEntityTypeConfiguration<SystemConfigurationHistory>
    {
        public void Configure(EntityTypeBuilder<SystemConfigurationHistory> builder)
        {
            builder.ToTable("SystemConfigurationsHistory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.OldValue).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.NewValue).HasColumnType("VARCHAR(250)").IsRequired();
        }
    }
}
