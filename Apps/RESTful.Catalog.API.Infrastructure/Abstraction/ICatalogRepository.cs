using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Helpers;

namespace RESTful.Catalog.API.Infrastructure.Abstraction
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms);
        Task<CatalogType> GetCatalogTypeByIdAsync(int id);
        Task CreateItemForCatalog(int ctgTypeId, CatalogItem ctgItem);
        Task DeleteItemFromCatalogAsync(int ctgTypeId, int ctgItemId);
        Task UpdateItemFromCatalogAsync(int ctgTypeId, int ctgItemId, CatalogItem ctgItem);
        bool Save();
    }
}
