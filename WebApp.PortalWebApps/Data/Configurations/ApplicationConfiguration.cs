using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalWebApps.WebApp.Data.Models;

namespace PortalWebApps.WebApp.Data.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Uri).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.KeyUserName).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.KeyUserMail).HasColumnType("VARCHAR(500)").IsRequired();
        }
    }
}
