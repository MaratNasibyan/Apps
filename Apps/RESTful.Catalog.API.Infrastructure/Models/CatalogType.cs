using System.Collections.Generic;

namespace RESTful.Catalog.API.Infrastructure.Models
{
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<CatalogItem> CatalogItems { get; set; } = new List<CatalogItem>();
       
    }
}
