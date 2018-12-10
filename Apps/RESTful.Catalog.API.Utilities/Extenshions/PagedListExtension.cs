using System.Collections.Generic;
using RESTful.Catalog.API.Utilities.Infra;
using RESTful.Catalog.API.Utilities.Resource;

namespace RESTful.Catalog.API.Utilities.Extenshions
{
    public static class PagedListExtension
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, ApiResourceParameters resourceParameters)
        {
            return PagedList<T>.Create(source, resourceParameters.PageNumber, resourceParameters.PageSize);
        }
    }
}
