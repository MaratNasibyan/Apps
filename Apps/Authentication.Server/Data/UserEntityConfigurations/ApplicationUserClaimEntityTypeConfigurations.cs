using Authentication.Server.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.Server.Data.UserEntityConfigurations
{
    public class ApplicationUserClaimEntityTypeConfigurations : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder.ToTable("UserClaims");
        }     
    }
}
