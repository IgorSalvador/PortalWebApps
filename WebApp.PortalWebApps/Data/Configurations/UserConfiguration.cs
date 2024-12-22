using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalWebApps.WebApp.Data.Models;

namespace PortalWebApps.WebApp.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(x => x.Profile).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARBINARY(MAX)").IsRequired();
        }
    }
}
