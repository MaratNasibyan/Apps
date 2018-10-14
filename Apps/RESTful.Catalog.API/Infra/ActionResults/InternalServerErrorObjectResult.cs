using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RESTful.Catalog.API.Infra.ActionResults
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
