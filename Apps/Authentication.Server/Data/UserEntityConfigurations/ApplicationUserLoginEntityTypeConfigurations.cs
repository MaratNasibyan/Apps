using Authentication.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Server.Data.UserEntityConfigurations
{
    public class ApplicationUserLoginEntityTypeConfigurations : IEntityTypeConfiguration<ApplicationUserLogin>
    {    
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.ToTable("UserLogins");
        }
    }
}
