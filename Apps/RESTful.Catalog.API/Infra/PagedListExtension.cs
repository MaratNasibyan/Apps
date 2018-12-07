using System.Collections.Generic;
using RESTful.Catalog.API.Infrastructure.Helpers;
using RESTful.Catalog.API.Infrastructure.Utilities;

namespace RESTful.Catalog.API.Infra
{
    public static class PagedListExtension
    {      
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, ApiResourceParameters resourceParameters)
        {
            return PagedList<T>.Create(source, resourceParameters.PageNumber, resourceParameters.PageSize);
        }    
    }
}
