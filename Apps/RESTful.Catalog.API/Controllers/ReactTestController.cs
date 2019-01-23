using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTful.Catalog.API.Utilities.Infra;

namespace RESTful.Catalog.API.Controllers
{
    public class ReactTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        //[Authorize]
      //  [HttpGet("{email}/{password}")]
        public IActionResult CallBackReact(string email, string password)
        {
            return Ok(ResponseSuccess.Create(email + "-" + password));
        }
    }
}