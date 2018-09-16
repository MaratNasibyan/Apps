using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

namespace RESTful.Catalog.API.Infrastructure.Repositories
{
    public  class CatalogRepository : ICatalogRepository
    {
        CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync()
        {
            return await _dbContext.CatalogTypes.ToListAsync();
        }
    }
}
