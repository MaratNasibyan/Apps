using Authentication.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Server.Data.UserEntityConfigurations
{
    public class ApplicationUserRoleEntityTypeConfigurations : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("UserRoles");        
        }
    }
}
