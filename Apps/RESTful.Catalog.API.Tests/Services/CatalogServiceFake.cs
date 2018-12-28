using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RESTful.Catalog.API.Utilities.Resource;
using RESTful.Catalog.API.Services.Abstraction;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Tests.Services
{
    class CatalogServiceFake : ICatalogService
    {
       
       
        public Task CreateCatalogItemAsync(int Id, CatalogItem ctgItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCatalogItem(int ctgTypeId, int ctgItemId)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogItem> GetCatalogItem(int Id, int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogType> GetCatalogItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CatalogItem>> GetCatalogItemsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CatalogType> GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms)
        {
            return FakeData.FakeData.GetCatalogType();
        }

        public Task UpdateCatalogItem(int ctgTypeId, int ctgItemId, CatalogItem ctgItem)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CatalogType>> ICatalogService.GetCatalogTypesAsync(CatalogResourceParameters ctgResourcePrms)
        {
            throw new NotImplementedException();
        }
    }
}
