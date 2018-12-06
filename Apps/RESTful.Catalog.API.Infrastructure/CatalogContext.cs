using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.EntityConfigurations;
using RESTful.Catalog.API.Infrastructure.Extenshions;
using RESTful.Catalog.API.Infrastructure.Settings;


namespace RESTful.Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext
    {
        private readonly IOptions<AppSettings> _settings;
        public CatalogContext(DbContextOptions<CatalogContext> options, IOptions<AppSettings> settings) : base(options)
        {
            _settings = settings;

            Database.EnsureCreated();
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }       
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {         
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());

            builder.Seed();        
        }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_settings.Value.ConnectionString);
        }
    }   
}


