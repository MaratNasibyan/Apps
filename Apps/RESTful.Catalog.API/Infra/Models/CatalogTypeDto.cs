using System.Collections.Generic;

namespace RESTful.Catalog.API.Infra.Models
{
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<CatalogItemDto> CatalogItems { get; set; } = new List<CatalogItemDto>();
    }
}
