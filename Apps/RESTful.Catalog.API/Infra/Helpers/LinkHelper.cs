using Microsoft.AspNetCore.Mvc;
using RESTful.Catalog.API.Infrastructure.Helpers;
using static RESTful.Catalog.API.Infrastructure.Enums;

namespace RESTful.Catalog.API.Infra.Helpers
{
    public class LinkHelper : ILinkHelper
    {
        private readonly IUrlHelper _urlHelper;

        public LinkHelper(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public string GenerateLink(string routeName, ApiResourceParameters apiResourceParameters, ResourceUriType uriType)
        {
            switch (uriType)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link(routeName, new
                    {
                        pageNumber = apiResourceParameters.PageNumber - 1,
                        pageSize = apiResourceParameters.PageSize
                    });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link(routeName, new
                    {
                        pageNumber = apiResourceParameters.PageNumber + 1,
                        pageSize = apiResourceParameters.PageSize
                    });
                default:
                    return _urlHelper.Link(routeName, new
                    {
                        pageNumber = apiResourceParameters.PageNumber,
                        pageSize = apiResourceParameters.PageSize
                    });
            }
        }
    }
}
