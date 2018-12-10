using RESTful.Catalog.API.Infrastructure.Helpers;
using static RESTful.Catalog.API.Infrastructure.Enums;

namespace RESTful.Catalog.API.Infra.Helpers
{
    public interface ILinkHelper
    {
        string GenerateLink(string routeName, ApiResourceParameters apiResourceParameters, ResourceUriType uriType);
    }
}
