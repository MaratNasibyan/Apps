namespace RESTful.Catalog.API.Utilities.Resource
{
    public class CatalogResourceParameters : ApiResourceParameters
    {
        public int? CatalogType { get; set; }
        public string Sort { get; set; }
    }
}
