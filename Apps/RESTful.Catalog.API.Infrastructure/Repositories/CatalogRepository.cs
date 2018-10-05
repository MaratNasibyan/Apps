using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using RESTful.Catalog.API.Infrastructure.Helpers;

namespace RESTful.Catalog.API.Infrastructure.Repositories
{
    public  class CatalogRepository : ICatalogRepository
    {
        CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms)
        {
               var collection =_dbContext.CatalogTypes
                        .Include(x => x.CatalogItems)                   
                        .ToListAsync();

            return await collection;
                   
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

        public async Task DeleteItemFromCatalogAsync(int ctgTypeId, int ctgItemId)
        {
            var deletedItem = await _dbContext.CatalogItems.Where(x => x.Id == ctgItemId && x.CatalogTypeId == ctgTypeId)
                           .FirstOrDefaultAsync();

            if (!(deletedItem is null))
            {
                _dbContext.CatalogItems.Remove(deletedItem);
            }
        }       

        public async Task UpdateItemFromCatalogAsync(int ctgTypeId, int ctgItemId, CatalogItem ctgItem)
        {
            var updatedItem = await _dbContext.CatalogItems.Where(x => x.Id == ctgItemId && x.CatalogTypeId == ctgTypeId)
                          .FirstOrDefaultAsync();

            if (!(updatedItem is null))
            {
                updatedItem.Name = ctgItem.Name;
                updatedItem.Description = ctgItem.Description;
            }
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
