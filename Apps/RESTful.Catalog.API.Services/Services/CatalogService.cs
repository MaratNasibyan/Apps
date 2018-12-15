using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Utilities.Resource;
using RESTful.Catalog.API.Services.Abstraction;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;

namespace RESTful.Catalog.API.Services.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task CreateCatalogItemAsync(int Id, CatalogItem ctgItem)
        {
           await _catalogRepository.CreateCatalogItem(Id, ctgItem);
        }

        public async Task DeleteCatalogItem(int ctgTypeId, int ctgItemId)
        {
           await _catalogRepository.DeleteCatalogItem(ctgTypeId, ctgItemId);
        }

        public async Task<CatalogItem> GetCatalogItem(int Id, int itemId)
        {
            return await _catalogRepository.GetCatalogItem(Id, itemId);
        }

        public async Task<CatalogType> GetCatalogItemByIdAsync(int id)
        {
            return await _catalogRepository.GetCatalogItemByIdAsync(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByIdAsync(int id)
        {
            return await _catalogRepository.GetCatalogItemsByIdAsync(id);
        }

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms)
        {
            return await _catalogRepository.GetCatalogTypesAsync(ctgResourcePrms);
        }

        public async Task UpdateCatalogItem(int ctgTypeId, int ctgItemId, CatalogItem ctgItem)
        {
           await _catalogRepository.UpdateCatalogItem(ctgTypeId, ctgItemId, ctgItem);
        }
    }
}
