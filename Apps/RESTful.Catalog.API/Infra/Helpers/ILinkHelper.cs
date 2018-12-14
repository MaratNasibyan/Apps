using RESTful.Catalog.API.Utilities.Resource;
using static RESTful.Catalog.API.Utilities.Infra.Enums;

namespace RESTful.Catalog.API.Infra.Helpers
{
    public interface ILinkHelper
    {
        string GenerateLink(string routeName, ApiResourceParameters apiResourceParameters, ResourceUriType uriType);
    }
}
