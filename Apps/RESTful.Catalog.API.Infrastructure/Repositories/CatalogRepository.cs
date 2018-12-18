using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RESTful.Catalog.API.Utilities.Resource;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

namespace RESTful.Catalog.API.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository, IDisposable
    {
        private readonly CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region CatalogController

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms)
        {
            var collection = await _dbContext.CatalogTypes
                             .Include(x => x.CatalogItems).ToListAsync();

            return collection;
        }

        public async Task<CatalogType> GetCatalogItemByIdAsync(int id)
        {
                return await _dbContext.CatalogTypes
                    .Include(x => x.CatalogItems)
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        #endregion

        #region CatalogItemController

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByIdAsync(int id)
        {
            return await _dbContext.CatalogItems                  
                    .Where(x => x.CatalogTypeId == id)
                    .ToListAsync();
        }

        public async Task<CatalogItem> GetCatalogItem(int Id, int itemId)
        {
            return await _dbContext.CatalogItems
                    .Where(x =>  x.CatalogTypeId == Id && x.Id == itemId)
                    .FirstOrDefaultAsync();
        }

        public async Task CreateCatalogItem(int ctgTypeId, CatalogItem ctgItem)
        {
            var ctgType = await GetCatalogItemByIdAsync(ctgTypeId);

            ctgType.CatalogItems.Add(ctgItem);
        }

        public async Task DeleteCatalogItem(int ctgTypeId, int ctgItemId)
        {
            var deletedItem = await _dbContext.CatalogItems.Where(x => x.Id == ctgItemId && x.CatalogTypeId == ctgTypeId)
                         .FirstOrDefaultAsync();

            if (!(deletedItem is null))
            {
                _dbContext.CatalogItems.Remove(deletedItem);
            }
        }

        public async Task UpdateCatalogItem(int Id, int itemId, CatalogItem ctgItem)
        {
            var updatedItem = await _dbContext.CatalogItems.Where(x => x.Id == itemId && x.CatalogTypeId == Id)
                         .FirstOrDefaultAsync();

            if (!(updatedItem is null))
            {
                updatedItem.Name = ctgItem.Name;
                updatedItem.Description = ctgItem.Description;
            }
        }

        #endregion

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        #region Dispose

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
