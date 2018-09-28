using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Infrastructure.Abstraction
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();
        Task<CatalogType> GetCatalogTypeByIdAsync(int id);
        Task CreateItemForCatalog(int ctgTypeId, CatalogItem ctgItem);
        Task DeleteItemFromCatalogAsync(int ctgTypeId, int ctgItemId);
        Task UpdateItemFromCatalogAsync(int ctgTypeId, int ctgItemId, CatalogItem ctgItem);
        bool Save();
    }
}
