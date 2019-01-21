using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Authentication.Server.Models;
using Authentication.Server.Configuration;

namespace Authentication.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IOptions<AuthSettings> _settings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<AuthSettings> settings)
           : base(options)
        {
            _settings = settings;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.Value.ConnectionString);
        }
    }
}
