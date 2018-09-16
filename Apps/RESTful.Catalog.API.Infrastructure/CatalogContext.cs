using Microsoft.EntityFrameworkCore;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.EntityConfigurations;
using RESTful.Catalog.API.Infrastructure.ModelBuilderExtenshions;

namespace RESTful.Catalog.API.Infrastructure
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
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
    }   
}


