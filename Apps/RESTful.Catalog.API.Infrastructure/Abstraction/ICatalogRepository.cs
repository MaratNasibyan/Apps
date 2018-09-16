using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Infrastructure.Abstraction
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();
    }
}
