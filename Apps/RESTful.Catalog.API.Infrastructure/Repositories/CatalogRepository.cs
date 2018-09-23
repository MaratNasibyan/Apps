using System.Linq;
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
                return await _dbContext.CatalogTypes
                    .Include(x => x.CatalogItems)
                    .ToListAsync();
        }

        public async Task<CatalogType> GetCatalogTypeByIdAsync(int id)
        {
                return await _dbContext.CatalogTypes
                    .Include(x => x.CatalogItems)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateItemForCatalog(int ctgTypeId, CatalogItem ctgItem)
        {
            var ctgType = await GetCatalogTypeByIdAsync(ctgTypeId);

            ctgType.CatalogItems.Add(ctgItem);
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
