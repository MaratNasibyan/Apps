using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.Catalog.API.Infra.Models
{
    public class CatalogItemForUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
