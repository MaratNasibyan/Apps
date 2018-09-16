using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Models;

namespace RESTful.Catalog.API.Infra.Models
{
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<CatalogItem> CatalogItems { get; set; }

        public CatalogTypeDto()
        {
            CatalogItems = new List<CatalogItem>();
        }
    }
}
