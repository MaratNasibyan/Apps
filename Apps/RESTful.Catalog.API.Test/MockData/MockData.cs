using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace RESTful.Catalog.API.Test.MockData
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
    }

    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<CatalogItem> CatalogItems { get; set; } = new List<CatalogItem>();

    }

    public static class MockData
    {
        
    }
}

