using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RESTful.Catalog.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
