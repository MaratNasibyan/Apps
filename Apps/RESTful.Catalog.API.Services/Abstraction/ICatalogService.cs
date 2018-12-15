using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Utilities.Resource;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Services.Abstraction
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms);
        Task<CatalogType> GetCatalogItemByIdAsync(int id);
        Task<IEnumerable<CatalogItem>> GetCatalogItemsByIdAsync(int id);
        Task<CatalogItem> GetCatalogItem(int Id, int itemId);
        Task CreateCatalogItemAsync(int Id, CatalogItem ctgItem);
        Task DeleteCatalogItem(int ctgTypeId, int ctgItemId);
        Task UpdateCatalogItem(int ctgTypeId, int ctgItemId, CatalogItem ctgItem);
    }
}
