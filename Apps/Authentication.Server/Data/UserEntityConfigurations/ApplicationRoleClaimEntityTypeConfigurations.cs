using Authentication.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Server.Data.UserEntityConfigurations
{
    public class ApplicationRoleClaimEntityTypeConfigurations : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("RoleClaims");         
        }
    }
}
