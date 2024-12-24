using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalWebApps.WebApp.Data.Models;

namespace PortalWebApps.WebApp.Data.Configurations
{
    public class SystemSettingsHistoryConfiguration : IEntityTypeConfiguration<SystemSettingHistory>
    {
        public void Configure(EntityTypeBuilder<SystemSettingHistory> builder)
        {
            builder.ToTable("SystemSettingsHistory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.OldValue).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.NewValue).HasColumnType("VARCHAR(250)").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.SystemsSettingsHistory).HasForeignKey(x => x.ChangedBy);
        }
    }
}
