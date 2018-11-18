using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Helpers;

namespace RESTful.Catalog.API.Infrastructure.Abstraction
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms);
        Task<CatalogType> GetCatalogItemByIdAsync(int id);      
        Task<IEnumerable<CatalogItem>> GetCatalogItemsByIdAsync(int id);
        Task<CatalogItem> GetCatalogItem(int Id, int itemId);
        Task CreateCatalogItem(int Id, CatalogItem ctgItem);
        Task DeleteCatalogItem(int ctgTypeId, int ctgItemId);
        Task UpdateCatalogItem(int ctgTypeId, int ctgItemId, CatalogItem ctgItem);     
        bool Save();
    }
}
