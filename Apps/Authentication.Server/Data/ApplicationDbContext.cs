using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Authentication.Server.Entities;
using Authentication.Server.Configuration;
using Authentication.Server.Data.UserEntityConfigurations;

namespace Authentication.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        private readonly IOptions<AuthSettings> _settings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<AuthSettings> settings)
           : base(options)
        {
            _settings = settings;

            Database.EnsureCreated();
        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationRoleEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserLoginEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserClaimEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserTokenEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationRoleClaimEntityTypeConfigurations());       
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.Value.ConnectionString);
        }
    }
}
