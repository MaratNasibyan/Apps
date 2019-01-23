using Authentication.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Server.Data.UserEntityConfigurations
{
    public class ApplicationUserTokenEntityTypeConfigurations : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable("UserTokens");
        }
    }
}
