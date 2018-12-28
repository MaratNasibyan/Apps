using RESTful.Catalog.API.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTful.Catalog.API.Tests.FakeData
{
    public class FakeData
    {
        public static IEnumerable<CatalogType> GetCatalogType()
        {
            var catalogTypes = new List<CatalogType>()
                {
                    new CatalogType
                    {
                        Id = 1,
                        Type = "Mug",
                        CatalogItems = new List<CatalogItem>
                        {
                            new CatalogItem
                            {
                                Id = 2,
                                Name = ".NET Black & White Mug",
                                Description = ".NET Black & White Mug",
                                Price = 8.5M,
                                PictureFileName = "2.png",
                                PictureUri = null,
                                CatalogTypeId = 1
                            }
                        }
                    }
                };

            return   catalogTypes;
        }
    }
}
